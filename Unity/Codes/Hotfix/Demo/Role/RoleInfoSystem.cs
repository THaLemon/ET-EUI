namespace ET
{
    [FriendClass(typeof (RoleInfo))]
    public static class RoleInfoSystem
    {
        public static void FromMessage(this RoleInfo self, RoleInfoProto roleInfo)
        {
            self.Id = roleInfo.Id;
            self.Name = roleInfo.Name;
            self.ServerId = roleInfo.ServerId;
            self.State = roleInfo.State;
            self.AccountId = roleInfo.AccountId;
            self.LastLoginTime = roleInfo.LastLoginTime;
            self.CreatedTime = roleInfo.CreatedTime;
        }

        public static RoleInfoProto ToMessage(this RoleInfo self)
        {
            return new RoleInfoProto()
            {
                Id = (int)self.Id,
                Name = self.Name,
                ServerId = self.ServerId,
                State = self.State,
                AccountId = self.AccountId,
                LastLoginTime = self.LastLoginTime,
                CreatedTime = self.CreatedTime,
            };
        }
    }
}