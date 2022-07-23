namespace ET
{
	public enum PlayerState
	{
		Disconnect,
		Gate,
		Game,
	}

	public sealed class Player: Entity, IAwake<string>, IAwake<long, long>
	{
		public long Account { get; set; }

		public long UnitId { get; set; }
		
		/// <summary>
		/// 通过SessionInstanceId找到player对应session
		/// </summary>
		public long SessionInstanceId { get; set; }
		
		public PlayerState PlayerState { get; set; }
	}
}