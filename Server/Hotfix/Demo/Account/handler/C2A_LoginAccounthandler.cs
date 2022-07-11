using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ET
{
    [FriendClass(typeof (Account))]
    [MessageHandler]
    public class C2A_LoginAccounthandler: AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error("请求的Scene错误, 当前请求的Scene为:{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            // 移除超时组件, 以此通过链接验证
            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            // 一旦链接,锁定session的状态,防止重复跑流程
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatly;
                response.Message = "重复链接";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            if (string.IsNullOrEmpty(request.AccountName) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_LoginInfoError;
                response.Message = "登录信息错误";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 验证账号名的正确性
            if (!Regex.IsMatch(request.AccountName.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_AccountNameError;
                response.Message = "账户名错误";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 验证密码的正确性
            if (!Regex.IsMatch(request.Password.Trim(), @"^(?=.*[0-9].*)(?=.*[A-Z].*)(?=.*[a-z].*).{6,15}$"))
            {
                response.Error = ErrorCode.ERR_AccountPasswordFormatError;
                response.Message = "密码错误";
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // using 作为语句，用于定义一个范围，在此范围的末尾将释放对象。
            // 在耗时的异步操作结束前(查询数据库等)阻挡玩家的发起的重复请求
            using (session.AddComponent<SessionLockingComponent>())
            {
                // 多个客户端输入相同的一组账密在此被阻挡
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountName.Trim().GetHashCode()))
                {
                    // 进数据库查
                    var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                            .Query<Account>(d => d.AccountName.Equals(request.AccountName.Trim()));
                    Account account = null;
                    if (accountInfoList != null && accountInfoList.Count > 0)
                    {
                        account = accountInfoList[0];
                        session.AddChild(account);
                        if (account.AccountType == (int)AccountType.BlackList)
                        {
                            response.Error = ErrorCode.ERR_AccountInBlackListError;
                            response.Message = "账户在黑名单中";
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }

                        if (!account.AccountPassword.Equals(request.Password))
                        {
                            response.Error = ErrorCode.ERR_AccountPasswordError;
                            response.Message = "密码错误";
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }
                    }
                    // 注册
                    else
                    {
                        account = session.AddChild<Account>();
                        account.AccountName = request.AccountName;
                        account.AccountPassword = request.Password;
                        account.CreateTime = TimeHelper.ServerNow();
                        account.AccountType = (int)AccountType.General;
                        // 保存到数据库
                        // session.DomainZone()标记了1或2服务器
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
                    }

                    // 登录
                    string token = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    var tokenComponent = session.DomainScene().GetComponent<TokenComponent>();
                    tokenComponent.Remove(account.Id);
                    tokenComponent.Add(account.Id, token);

                    response.AccountId = account.Id;
                    response.Token = token;
                    reply();
                    account?.Dispose();
                }
            }
        }
    }
}