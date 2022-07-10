
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_Test_RumDestroySystem : DestroySystem<Scroll_Item_Test_Rum> 
	{
		public override void Destroy( Scroll_Item_Test_Rum self )
		{
			self.DestroyWidget();
		}
	}
}
