using System;

namespace ET
{
    [FriendClass(typeof (RoleInfo))]
    [MessageHandler]
    public class C2A_DeleteRoleHandler: AMRpcHandler<C2A_DeleteRole, A2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2A_DeleteRole request, A2C_DeleteRole response, Action reply)
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

            var token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            // token比对
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 上锁,防止重复处理
            using (session.AddComponent<SessionLockingComponent>())
            // 在数据库中操作角色
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.AccountId.GetHashCode()))
            {
                var roleInfos = await DBManagerComponent.Instance.GetZoneDB(request.ServerId).Query<RoleInfo>(
                    d => d.AccountId == request.AccountId && d.ServerId == request.ServerId);
                if (roleInfos == null || roleInfos.Count <= 0)
                {
                    response.Error = ErrorCode.ERR_RoleIsNotExits;
                    reply();
                    return;
                }

                var roleInfo = roleInfos[0];
                // Todo:为什么要添加为子对象
                session.AddChild(roleInfo);
                roleInfo.State = (int)RoleState.Freeze;
                await DBManagerComponent.Instance.GetZoneDB(request.ServerId).Save(roleInfo);
                response.DeletedRoleInfoId = roleInfo.Id;
                roleInfo?.Dispose();
                reply();
            }
        }
    }
}