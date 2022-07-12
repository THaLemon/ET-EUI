namespace ET
{
    public class ServerInfosComponentDestroySystem:DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
            foreach (var serverInfo in self.ServerInfoList)
            {
                // 触发serverInfo的释放方法?
                serverInfo?.Dispose();
            }
            self.ServerInfoList.Clear();
        }
    }
    public class ServerInfosComponentAwakeSystem:AwakeSystem<ServerInfosComponent>
    {
        public override void Awake(ServerInfosComponent self)
        {
            
        }
    }
    public static class ServerInfosComponentSystem
    {
        public static void Add(this ServerInfosComponent self, ServerInfo info)
        {
            self.ServerInfoList.Add(info);
        }
    }
}