using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class AccountSessionsComponent: Entity, IAwake, IDestroy
    {
        /// <summary>
        /// 通过accountId匹配session
        /// </summary>
        public Dictionary<long, long> AccountSessionsDict = new Dictionary<long, long>();
    }
}