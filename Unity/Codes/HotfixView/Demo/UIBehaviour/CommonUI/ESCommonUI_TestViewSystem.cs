
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESCommonUI_TestAwakeSystem : AwakeSystem<ESCommonUI_Test,Transform> 
	{
		public override void Awake(ESCommonUI_Test self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonUI_TestDestroySystem : DestroySystem<ESCommonUI_Test> 
	{
		public override void Destroy(ESCommonUI_Test self)
		{
			self.DestroyWidget();
		}
	}
}
