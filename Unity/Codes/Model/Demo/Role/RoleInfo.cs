namespace ET
{
    public enum RoleState
    {
        Normal = 0,
        Freeze = 1,
    }

    public class RoleInfo: Entity, IAwake
    {
        /// <summary>
        /// 角色名字
        /// </summary>
        public string Name;

        /// <summary>
        /// 所属区服ID
        /// </summary>
        public int ServerId;

        /// <summary>
        /// 角色状态
        /// </summary>
        public int State;

        /// <summary>
        /// 所属账号ID
        /// </summary>
        public long AccountId;

        /// <summary>
        /// 此前登陆时间
        /// </summary>
        public long LastLoginTime;

        /// <summary>
        /// 创建时间
        /// </summary>
        public long CreatedTime;
    }
}