using System;
using CommandLine;

namespace ET
{
    [FriendClass(typeof(AccountInfoComponent))]
    public static class LoginHelper
    {
        public static async ETTask<int> Login(Scene zoneScene, string address, string account, string password)
        {
            // try
            // {
            //     // 创建一个ETModel层的Session
            //     R2C_Login r2CLogin;
            //     Session session = null;
            //     try
            //     {
            //         session = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
            //         {
            //             r2CLogin = (R2C_Login) await session.Call(new C2R_Login() { Account = account, Password = password });
            //         }
            //     }
            //     finally
            //     {
            //         session?.Dispose();
            //     }
            //
            //     // 创建一个gate Session,并且保存到SessionComponent中
            //     Session gateSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(r2CLogin.Address));
            //     gateSession.AddComponent<PingComponent>();
            //     zoneScene.AddComponent<SessionComponent>().Session = gateSession;
            //
            //     G2C_LoginGate g2CLoginGate = (G2C_LoginGate)await gateSession.Call(
            //         new C2G_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId});
            //
            //     Log.Debug("登陆gate成功!");
            //
            //     Game.EventSystem.PublishAsync(new EventType.LoginFinish() {ZoneScene = zoneScene}).Coroutine();
            // }
            // catch (Exception e)
            // {
            //     Log.Error(e);
            // }
            A2C_LoginAccount a2C_LoginAccount = null;
            Session accountSession = null;
            try
            {
                accountSession = zoneScene.GetComponent<NetKcpComponent>().Create(NetworkHelper.ToIPEndPoint(address));
                password = MD5Helper.StringMD5(password);
                a2C_LoginAccount = (A2C_LoginAccount)await accountSession.Call(new C2A_LoginAccount() { AccountName = account, Password = password });
            }
            catch (Exception e)
            {
                accountSession?.Dispose();
                Log.Error(e.ToString());
                return ErrorCode.ERR_NetWorkError;
            }

            if (a2C_LoginAccount.Error != ErrorCode.ERR_Success)
            {
                accountSession?.Dispose();
                return a2C_LoginAccount.Error;
            }

            // 保存链接的Session
            zoneScene.AddComponent<SessionComponent>().Session = accountSession;
            // 与服务端的SessionIdleCheckerComponent对应,维持心跳包
            zoneScene.GetComponent<SessionComponent>().Session.AddComponent<PingComponent>();
            
            zoneScene.GetComponent<AccountInfoComponent>().Token = a2C_LoginAccount.Token;
            zoneScene.GetComponent<AccountInfoComponent>().AccountId = a2C_LoginAccount.AccountId;

            return ErrorCode.ERR_Success;
        }
    }
}