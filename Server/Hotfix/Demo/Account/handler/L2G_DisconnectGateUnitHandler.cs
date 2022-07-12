using System;
namespace ET
{
    [ActorMessageHandler]
    public class L2G_DisconnectGateUnitHandler :AMActorRpcHandler<Scene, L2G_DisconnectGateUnit,G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene sceneGate, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            long accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.GateLoginLock, accountId.GetHashCode()))
            {
                var playerComponent = sceneGate.GetComponent<PlayerComponent>();
                Player gateUnit = playerComponent.Get(accountId);
                if (gateUnit==null)
                {
                    reply();
                    return;
                }
                playerComponent.Remove(accountId);
                // Todo:玩家被动下线的逻辑
                
                gateUnit.Dispose();
                
            }
            reply();
        }
    }
}