using System;

namespace ET
{
    [ActorMessageHandler]
    public class R2G_GetLoginGateKeyHandler:AMActorRpcHandler<Scene, R2G_GetLoginGateKey,G2R_GetLoginGateKey>
    {
        protected override async ETTask Run(Scene scene, R2G_GetLoginGateKey request, G2R_GetLoginGateKey response, Action reply)
        {
            if (scene.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error("请求的Scene错误, 当前请求的Scene为:{session.DomainScene().SceneType}");
                response.Error = ErrorCode.ERR_RequestSceneTypeErr;
                reply();
                return;
            }

            string key = RandomHelper.RandInt64().ToString() + TimeHelper.ServerNow().ToString();
            scene.GetComponent<GateSessionKeyComponent>().Remove(request.AccountId);
            scene.GetComponent<GateSessionKeyComponent>().Add(request.AccountId, key);
            response.GateSessionKey = key.ToString();
            reply();
            await ETTask.CompletedTask;
        }
    }
}