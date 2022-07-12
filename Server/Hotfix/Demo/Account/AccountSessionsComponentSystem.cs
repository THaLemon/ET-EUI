namespace ET
{
    public class AccountSessionsComponentDestroySystem: DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.AccountSessionsDict.Clear();
        }
    }

    [FriendClass(typeof (AccountSessionsComponent))]
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if (!self.AccountSessionsDict.TryGetValue(accountId, out long instanceId))
            {
                return 0;
            }

            return instanceId;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long instanceId)
        {
            if (self.AccountSessionsDict.ContainsKey(accountId))
            {
                self.AccountSessionsDict[accountId] = instanceId;
            }
            else
            {
                self.AccountSessionsDict.Add(accountId, instanceId);
            }
        }
        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            if (self.AccountSessionsDict.ContainsKey(accountId))
            {
                self.AccountSessionsDict.Remove(accountId);
            }
        }

    }
}