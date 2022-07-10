
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESCommonUI_Test_03AwakeSystem : AwakeSystem<ESCommonUI_Test_03,Transform> 
	{
		public override void Awake(ESCommonUI_Test_03 self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonUI_Test_03DestroySystem : DestroySystem<ESCommonUI_Test_03> 
	{
		public override void Destroy(ESCommonUI_Test_03 self)
		{
			self.DestroyWidget();
		}
	}
}
