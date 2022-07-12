using System;

namespace ET
{
    [ActorMessageHandler]
    public class A2L_LoginAccountRequestHandler: AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            var accountId = request.AccountId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenterLock, accountId.GetHashCode()))
            {
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    reply();
                    return;
                }

                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
                var gate = RealmGateAddressHelper.GetGate(zone, accountId);
                var g2L_DisconnectGateUnit =
                        (G2L_DisconnectGateUnit)await MessageHelper.CallActor(gate.InstanceId,
                            new L2G_DisconnectGateUnit() { AccountId = accountId });
                response.Error = g2L_DisconnectGateUnit.Error;
                reply();
            }
        }
    }
}