using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof (Scene))]
    [ChildType(typeof (ServerInfo))]
    public class ServerInfosComponent: Entity, IAwake, IDestroy
    {
        public List<ServerInfo> ServerInfoList = new List<ServerInfo>();
        /// <summary>
        /// 记录当前所选区服Id
        /// </summary>
        public int CurrentServerId = 0;
    }
}