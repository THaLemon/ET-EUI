using System;

namespace ET
{
    [ActorMessageHandler]
    public class L2G_DisconnectGateUnitHandler: AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene sceneGate, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            long accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, accountId.GetHashCode()))
            {
                var playerComponent = sceneGate.GetComponent<PlayerComponent>();
                Player player = playerComponent.Get(accountId); // = gateunit
                if (player == null)
                {
                    reply();
                    return;
                }

                // playerComponent.Remove(accountId);
                // palyer.Dispose();
                
                sceneGate.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                Session gateSession = Game.EventSystem.Get(player.SessionInstanceId) as Session;
                if (gateSession != null && !gateSession.IsDisposed)
                {
                    gateSession.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_OtherAccountLogin });
                    gateSession.Disconnect().Coroutine();
                }

                player.SessionInstanceId = 0;
                player.AddComponent<PlayerOfflineOutTimeComponent>();

            }

            reply();
        }
    }
}