using System;

namespace ET
{
    public class C2A_GetRealmKeyHandler: AMRpcHandler<C2A_GetRealmKey, A2C_GetRealmKey>
    {
        protected override async ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
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

            // 验证token
            var token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenERR;
                response.Message = "token验证失败";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            // 锁定到登录流程
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountId.GetHashCode()))
            {
                // 找到当前区服所属的网关负载均衡服务Realm
                var realmStartSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);
                var r2a_GetRealmKey = (R2A_GetRealmKey)await MessageHelper.CallActor(realmStartSceneConfig.InstanceId,
                    new A2R_GetRealmKey() { AccountId = request.AccountId });

                if (r2a_GetRealmKey.Error != ErrorCode.ERR_Success)
                {
                    Log.Error(r2a_GetRealmKey.Error.ToString());
                    reply();
                    session.Disconnect().Coroutine();
                    return;
                }

                response.RealmKey = r2a_GetRealmKey.RealmKey;
                response.RealmAddress = realmStartSceneConfig.OuterIPPort.ToString();
                reply();
                session.Disconnect().Coroutine(); // 断开account与client的链接
            }
        }
    }
}