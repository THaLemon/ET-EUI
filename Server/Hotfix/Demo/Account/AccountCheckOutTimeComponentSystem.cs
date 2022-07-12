﻿using System;
using MongoDB.Driver.Core.Events;

namespace ET
{
    [Timer(TimerType.AccountSessionCheckOutTime)]
    public class AccountCheckOutTimer: ATimer<AccountCheckOutTimeComponent>
    {
        public override void Run(AccountCheckOutTimeComponent self)
        {
            try
            {
                self.DeleteSession();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }

    public class AccountCheckOutTimeComponentAwakeSystem: AwakeSystem<AccountCheckOutTimeComponent, long>
    {
        public override void Awake(AccountCheckOutTimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            TimerComponent.Instance.Remove(ref self.Timer);
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 600000, TimerType.AccountSessionCheckOutTime, self);
        }
    }

    public class AccountCheckOutTimeComponentDestroySystem: DestroySystem<AccountCheckOutTimeComponent>
    {
        public override void Destroy(AccountCheckOutTimeComponent self)
        {
            self.AccountId = 0;
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    [FriendClass(typeof (AccountCheckOutTimeComponent))]
    public static class AccountCheckOutTimeComponentSystem
    {
        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            var session = self.GetParent<Session>();
            long sessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(self.AccountId);
            if (sessionInstanceId.Equals(session.InstanceId))
            {
                session.DomainScene().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);
            }

            session?.Send(new A2C_Disconnect() { Error = 1 });
            // 长期无操作,踢下去
            session?.Disconnect().Coroutine();
        }
    }
}