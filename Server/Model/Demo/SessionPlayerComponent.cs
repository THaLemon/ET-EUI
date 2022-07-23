namespace ET
{
	/// <summary>
	/// 这个组件保存session与player的链接信息,通过session找palyer
	/// </summary>
	[ComponentOf(typeof(Session))]
	public class SessionPlayerComponent : Entity, IAwake, IDestroy
	{
		public long PlayerId;
		public long PlayerInstanceId;
		public long AccountId;
	}
}