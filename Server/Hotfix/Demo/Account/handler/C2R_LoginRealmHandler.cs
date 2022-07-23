using System;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

namespace ET
{
    public class C2R_LoginRealmHandler: AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Realm)
            {
                Log.Error("请求的Scene错误, 当前请求的Scene为:{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            // 一旦链接,锁定session的状态,防止重复跑流程
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatly;
                response.Message = "重复请求";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            Scene domainScene = session.DomainScene();
            // 令牌token验证
            string token = domainScene.GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.RealmKey)
            {
                response.Error = ErrorCode.ERR_TokenERR;
                response.Message = "token验证失败";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 移除令牌
            domainScene.GetComponent<TokenComponent>().Remove(request.AccountId);

            using (session.AddComponent<SessionLockingComponent>())
            // 锁定到登录流程
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginRealm, request.AccountId.GetHashCode()))
            {
                // 取模固定分配一个Gate
                var config = RealmGateAddressHelper.GetGate(domainScene.Zone, request.AccountId);
                // 向gate请求一个key,客户端将拿着这个key链接gate
                var g2R_GetLoginGateKey =
                        (G2R_GetLoginGateKey)await MessageHelper.CallActor(config.InstanceId,
                            new R2G_GetLoginGateKey() { AccountId = request.AccountId, });

                if (g2R_GetLoginGateKey.Error != ErrorCode.ERR_Success)
                {
                    response.Error = g2R_GetLoginGateKey.Error;
                    reply();
                    return;
                }

                response.GateAddress = config.OuterIPPort.ToString();
                response.GateSessionKey = g2R_GetLoginGateKey.GateSessionKey;
                reply();
                // 断开realm与client的链接
                session.Disconnect().Coroutine();
            }
            await ETTask.CompletedTask;
        }
    }
}