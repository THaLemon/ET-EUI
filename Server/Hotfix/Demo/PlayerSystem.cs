namespace ET
{
    [FriendClass(typeof(Player))]
    public static class PlayerSystem
    {
        [ObjectSystem]
        public class PlayerAwakeSystem : AwakeSystem<Player, string>
        {
            public override void Awake(Player self, string a)
            {
                // self.Account = a;
            }
        }

        public class PlayerAwakenSystem: AwakeSystem<Player,long,long>
        {
            public override void Awake(Player self, long accountId, long roleId)
            {
                self.Account = accountId;
                self.UnitId = roleId;
            }
        }
    }
}