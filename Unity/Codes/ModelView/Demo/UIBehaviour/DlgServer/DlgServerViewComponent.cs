
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Button Ebtn_chooseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_chooseButton == null )
     			{
		    		this.m_Ebtn_chooseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_choose");
     			}
     			return this.m_Ebtn_chooseButton;
     		}
     	}

		public UnityEngine.UI.Image Ebtn_chooseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_chooseImage == null )
     			{
		    		this.m_Ebtn_chooseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_choose");
     			}
     			return this.m_Ebtn_chooseImage;
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
		    		this.m_ELabel_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Ebtn_choose/ELabel_");
     			}
     			return this.m_ELabel_Text;
     		}
     	}

		public UnityEngine.UI.Image ELoop_ServerImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoop_ServerImage == null )
     			{
		    		this.m_ELoop_ServerImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ELoop_Server");
     			}
     			return this.m_ELoop_ServerImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoop_ServerLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoop_ServerLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoop_ServerLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"ELoop_Server");
     			}
     			return this.m_ELoop_ServerLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_Ebtn_chooseButton = null;
			this.m_Ebtn_chooseImage = null;
			this.m_ELabel_Text = null;
			this.m_ELoop_ServerImage = null;
			this.m_ELoop_ServerLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_Ebtn_chooseButton = null;
		private UnityEngine.UI.Image m_Ebtn_chooseImage = null;
		private UnityEngine.UI.Text m_ELabel_Text = null;
		private UnityEngine.UI.Image m_ELoop_ServerImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoop_ServerLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
