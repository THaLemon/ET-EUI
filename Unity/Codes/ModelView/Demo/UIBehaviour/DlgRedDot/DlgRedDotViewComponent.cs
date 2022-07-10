
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRedDotViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button E_rootButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_rootButton == null )
     			{
		    		this.m_E_rootButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_root");
     			}
     			return this.m_E_rootButton;
     		}
     	}

		public UnityEngine.UI.Image E_rootImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_rootImage == null )
     			{
		    		this.m_E_rootImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_root");
     			}
     			return this.m_E_rootImage;
     		}
     	}

		public UnityEngine.UI.Button E_BagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagButton == null )
     			{
		    		this.m_E_BagButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Bag");
     			}
     			return this.m_E_BagButton;
     		}
     	}

		public UnityEngine.UI.Image E_BagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagImage == null )
     			{
		    		this.m_E_BagImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Bag");
     			}
     			return this.m_E_BagImage;
     		}
     	}

		public UnityEngine.UI.Button E_BagNode1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagNode1Button == null )
     			{
		    		this.m_E_BagNode1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BagNode1");
     			}
     			return this.m_E_BagNode1Button;
     		}
     	}

		public UnityEngine.UI.Image E_BagNode1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagNode1Image == null )
     			{
		    		this.m_E_BagNode1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BagNode1");
     			}
     			return this.m_E_BagNode1Image;
     		}
     	}

		public UnityEngine.UI.Button E_BagNode2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagNode2Button == null )
     			{
		    		this.m_E_BagNode2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_BagNode2");
     			}
     			return this.m_E_BagNode2Button;
     		}
     	}

		public UnityEngine.UI.Image E_BagNode2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BagNode2Image == null )
     			{
		    		this.m_E_BagNode2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_BagNode2");
     			}
     			return this.m_E_BagNode2Image;
     		}
     	}

		public UnityEngine.UI.Button E_MailButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailButton == null )
     			{
		    		this.m_E_MailButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Mail");
     			}
     			return this.m_E_MailButton;
     		}
     	}

		public UnityEngine.UI.Image E_MailImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailImage == null )
     			{
		    		this.m_E_MailImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Mail");
     			}
     			return this.m_E_MailImage;
     		}
     	}

		public UnityEngine.UI.Button E_MailNode1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailNode1Button == null )
     			{
		    		this.m_E_MailNode1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MailNode1");
     			}
     			return this.m_E_MailNode1Button;
     		}
     	}

		public UnityEngine.UI.Image E_MailNode1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailNode1Image == null )
     			{
		    		this.m_E_MailNode1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MailNode1");
     			}
     			return this.m_E_MailNode1Image;
     		}
     	}

		public UnityEngine.UI.Button E_MailNode2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailNode2Button == null )
     			{
		    		this.m_E_MailNode2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_MailNode2");
     			}
     			return this.m_E_MailNode2Button;
     		}
     	}

		public UnityEngine.UI.Image E_MailNode2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_MailNode2Image == null )
     			{
		    		this.m_E_MailNode2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_MailNode2");
     			}
     			return this.m_E_MailNode2Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_E_rootButton = null;
			this.m_E_rootImage = null;
			this.m_E_BagButton = null;
			this.m_E_BagImage = null;
			this.m_E_BagNode1Button = null;
			this.m_E_BagNode1Image = null;
			this.m_E_BagNode2Button = null;
			this.m_E_BagNode2Image = null;
			this.m_E_MailButton = null;
			this.m_E_MailImage = null;
			this.m_E_MailNode1Button = null;
			this.m_E_MailNode1Image = null;
			this.m_E_MailNode2Button = null;
			this.m_E_MailNode2Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_E_rootButton = null;
		private UnityEngine.UI.Image m_E_rootImage = null;
		private UnityEngine.UI.Button m_E_BagButton = null;
		private UnityEngine.UI.Image m_E_BagImage = null;
		private UnityEngine.UI.Button m_E_BagNode1Button = null;
		private UnityEngine.UI.Image m_E_BagNode1Image = null;
		private UnityEngine.UI.Button m_E_BagNode2Button = null;
		private UnityEngine.UI.Image m_E_BagNode2Image = null;
		private UnityEngine.UI.Button m_E_MailButton = null;
		private UnityEngine.UI.Image m_E_MailImage = null;
		private UnityEngine.UI.Button m_E_MailNode1Button = null;
		private UnityEngine.UI.Image m_E_MailNode1Image = null;
		private UnityEngine.UI.Button m_E_MailNode2Button = null;
		private UnityEngine.UI.Image m_E_MailNode2Image = null;
		public Transform uiTransform = null;
	}
}
