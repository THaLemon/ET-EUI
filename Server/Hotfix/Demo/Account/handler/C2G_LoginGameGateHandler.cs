using System;
using System.Security;

namespace ET
{
    [FriendClass(typeof(SessionPlayerComponent))]
    public class C2G_LoginGameGateHandler: AMRpcHandler<C2G_LoginGameGate, G2C_LoginGameGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error("请求的Scene错误, 当前请求的Scene为:{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            // gate网关将与客户端保持长时间链接
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatly;
                reply();
                return;
            }

            Scene scene = session.DomainScene();
            string tokenKey = scene.GetComponent<GateSessionKeyComponent>().Get(request.AccountId);
            if (tokenKey == null || !tokenKey.Equals(request.Key))
            {
                response.Error = ErrorCode.ERR_ConnectGateKeyErr;
                response.Message = "Gate key验证失败!";
                reply();
                session?.Disconnect().Coroutine();
            }

            scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);

            long instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
                    // 锁定登录流程
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, request.AccountId.GetHashCode()))
            {
                if (instanceId != session.InstanceId)
                {
                    return;
                }

                var config = StartSceneConfigCategory.Instance.LoginCenterConfig;
                var l2G_AddLoginRecord = (L2G_AddLoginRecord)await MessageHelper.CallActor(config.InstanceId,
                    new G2L_AddLoginRecord() { AccountId = request.AccountId, ServerId = scene.Zone, });
                if (l2G_AddLoginRecord.Error != ErrorCode.ERR_Success)
                {
                    response.Error = l2G_AddLoginRecord.Error;
                    reply();
                    session?.Disconnect().Coroutine();
                    return;
                }

                Player player = scene.GetComponent<PlayerComponent>().Get(request.AccountId);
                if (player == null)
                {
                    // 添加一个新的GateUnit
                    player = scene.GetComponent<PlayerComponent>().AddChildWithId<Player, long, long>(request.RoleId, request.AccountId, request.RoleId);
                    player.PlayerState = PlayerState.Gate;
                    scene.GetComponent<PlayerComponent>().Add(player);
                    session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
                }
                else
                {
                    scene.RemoveComponent<PlayerOfflineOutTimeComponent>();
                }

                // session通过sessionPlayerComponent找到对应player
                session.AddComponent<SessionPlayerComponent>().PlayerId = player.Id;
                session.GetComponent<SessionPlayerComponent>().PlayerInstanceId = player.InstanceId;
                session.GetComponent<SessionPlayerComponent>().AccountId = request.AccountId;
                // player通过SessionInstanceId找到对应session
                player.SessionInstanceId = session.InstanceId;
            }
        }
    }
}