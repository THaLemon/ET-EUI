using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[ObjectSystem]
	public class ESCommonUI_Test_02AwakeSystem: AwakeSystem<ESCommonUI_Test_02, Transform>
	{
		public override void Awake(ESCommonUI_Test_02 self, Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESCommonUI_Test_02DestroySystem: DestroySystem<ESCommonUI_Test_02>
	{
		public override void Destroy(ESCommonUI_Test_02 self)
		{
			self.DestroyWidget();
		}
	}
}