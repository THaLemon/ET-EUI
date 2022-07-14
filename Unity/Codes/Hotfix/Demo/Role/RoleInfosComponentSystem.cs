namespace ET
{
    public class RoleInfosComponentSystemDestroySystem:DestroySystem<RoleInfosComponent>
    {
        public override void Destroy(RoleInfosComponent self)
        {
            foreach (var roleInfo in self.RoleInfos)
            {
                roleInfo?.Dispose();
            }
            self.RoleInfos.Clear();
            self.CurrentRoleId = 0;
        }
    }
    // public class RoleInfosComponentAwakeSystem:AwakeSystem<RoleInfosComponent>
    // {
    //     public override void Awake(RoleInfosComponent self)
    //     {
    //         
    //     }
    // }
    public static class  RoleInfosComponentSystem
    {
        
    }
}