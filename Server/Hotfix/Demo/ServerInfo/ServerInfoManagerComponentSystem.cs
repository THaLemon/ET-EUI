﻿namespace ET
{
    public class ServerInfoManagerComponentAwakeSystem: AwakeSystem<ServerInfoManagerComponent>
    {
        public override void Awake(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    public class ServerInfoManagerComponentDestroySystem: DestroySystem<ServerInfoManagerComponent>
    {
        public override void Destroy(ServerInfoManagerComponent self)
        {
            foreach (var serverInfo in self.ServerInfos)
            {
                serverInfo?.Dispose();
            }

            self.ServerInfos.Clear();
        }
    }

    public class ServerInfoManagerComponentLoadSystem: LoadSystem<ServerInfoManagerComponent>
    {
        /// <summary>
        /// 在热重载后调用
        /// </summary>
        public override void Load(ServerInfoManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    [FriendClass(typeof (ServerInfoManagerComponent))]
    [FriendClass(typeof (ServerInfo))]
    public static class ServerInfoManagerComponentSystem
    {

        public static async ETTask Awake(this ServerInfoManagerComponent self)
        {
            // 从数据库中获取服务器列表信息
            var serverInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<ServerInfo>(d => true);
            if (serverInfoList == null || serverInfoList.Count <= 0)
            {
                Log.Error("ServerList is empty");
                self.ServerInfos.Clear();
                var serverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();
                foreach (var info in serverInfoConfigs.Values)
                {
                    ServerInfo newServerInfo = self.AddChildWithId<ServerInfo>(info.Id);
                    newServerInfo.ServerName = info.ServerName;
                    newServerInfo.Status = (int)ServerStatus.Normal;
                    self.ServerInfos.Add(newServerInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(newServerInfo);
                }

                return;
            }

            self.ServerInfos.Clear();
            foreach (ServerInfo serverInfo in serverInfoList)
            {
                // 挂载到层级树当中?
                self.AddChild(serverInfo);
                self.ServerInfos.Add(serverInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}