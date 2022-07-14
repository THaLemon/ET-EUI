using System;
using MongoDB.Driver.Core.Servers;

namespace ET
{
    [MessageHandler]
    public  class C2A_CreateRoleHandler :AMRpcHandler<C2A_CreateRole,A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error("请求的Scene错误, 当前请求的Scene为:{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }
            
            // 一旦链接,锁定session的状态,防止重复跑流程
            if (session.GetComponent<SessionLockingComponent>() != null) {
                response.Error = ErrorCode.ERR_RequestRepeatly;
                response.Message = "重复请求";
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            
            var token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            // token比对
            if (token==null||token!=request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }
            // 角色名字错误
            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsEmptyError;
                reply();
                return;
            }
            
            // 上锁,防止重复处理
            using (session.AddComponent<SessionLockingComponent>())
            {
                // 角色名字查重
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.RoleNameLock, request.AccountId.GetHashCode()))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<RoleInfo>(
                        d => d.Name == request.Name && d.ServerId == request.ServerId);
                    if (roleInfos != null && roleInfos.Count >= 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameIsRepeatedError;
                        reply();
                        return;
                    }
                    // 创建角色信息
                    var newRoleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    newRoleInfo.Name = request.Name;
                    newRoleInfo.State = (int)RoleState.Normal;
                    newRoleInfo.ServerId = request.ServerId;
                    newRoleInfo.AccountId = request.AccountId;
                    newRoleInfo.CreatedTime = TimeHelper.ServerNow();
                    newRoleInfo.LastLoginTime = 0;

                    await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(newRoleInfo);

                    response.RoleInfo = newRoleInfo.ToMessage();
                    reply();
                    newRoleInfo?.Dispose();
                }
            }
        }
    }
}