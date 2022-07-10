
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESCommonUI_Test_02 : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button EButton_CommonUI_TestButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CommonUI_TestButton == null )
     			{
		    		this.m_EButton_CommonUI_TestButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_CommonUI_Test");
     			}
     			return this.m_EButton_CommonUI_TestButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CommonUI_TestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CommonUI_TestImage == null )
     			{
		    		this.m_EButton_CommonUI_TestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_CommonUI_Test");
     			}
     			return this.m_EButton_CommonUI_TestImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Text == null )
     			{
		    		this.m_ELabel_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EButton_CommonUI_Test/ELabel_");
     			}
     			return this.m_ELabel_Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_CommonUI_TestButton = null;
			this.m_EButton_CommonUI_TestImage = null;
			this.m_ELabel_Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_CommonUI_TestButton = null;
		private UnityEngine.UI.Image m_EButton_CommonUI_TestImage = null;
		private UnityEngine.UI.Text m_ELabel_Text = null;
		public Transform uiTransform = null;
	}
}
