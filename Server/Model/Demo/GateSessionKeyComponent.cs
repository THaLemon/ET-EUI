using System.Collections.Generic;

namespace ET
{
	[ComponentOf(typeof(Scene))]
	public class GateSessionKeyComponent : Entity, IAwake
	{
		/// <summary>
		/// 使用accountId匹配Key
		/// </summary>
		public readonly Dictionary<long, string> sessionKey = new Dictionary<long, string>();
	}
}