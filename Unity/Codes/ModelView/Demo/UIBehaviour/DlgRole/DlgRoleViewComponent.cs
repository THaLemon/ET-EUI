
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRoleViewComponent : Entity,IAwake,IDestroy 
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

		public UnityEngine.UI.Button Ebtn_deleteRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_deleteRoleButton == null )
     			{
		    		this.m_Ebtn_deleteRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_deleteRole");
     			}
     			return this.m_Ebtn_deleteRoleButton;
     		}
     	}

		public UnityEngine.UI.Image Ebtn_deleteRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_deleteRoleImage == null )
     			{
		    		this.m_Ebtn_deleteRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_deleteRole");
     			}
     			return this.m_Ebtn_deleteRoleImage;
     		}
     	}

		public UnityEngine.UI.Button Ebtn_createRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_createRoleButton == null )
     			{
		    		this.m_Ebtn_createRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_createRole");
     			}
     			return this.m_Ebtn_createRoleButton;
     		}
     	}

		public UnityEngine.UI.Image Ebtn_createRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_createRoleImage == null )
     			{
		    		this.m_Ebtn_createRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_createRole");
     			}
     			return this.m_Ebtn_createRoleImage;
     		}
     	}

		public UnityEngine.UI.Button Ebtn_startGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_startGameButton == null )
     			{
		    		this.m_Ebtn_startGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_startGame");
     			}
     			return this.m_Ebtn_startGameButton;
     		}
     	}

		public UnityEngine.UI.Image Ebtn_startGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_Ebtn_startGameImage == null )
     			{
		    		this.m_Ebtn_startGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_startGame");
     			}
     			return this.m_Ebtn_startGameImage;
     		}
     	}

		public UnityEngine.UI.InputField EInput_roleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_roleNameInputField == null )
     			{
		    		this.m_EInput_roleNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EInput_roleName");
     			}
     			return this.m_EInput_roleNameInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_roleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_roleNameImage == null )
     			{
		    		this.m_EInput_roleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInput_roleName");
     			}
     			return this.m_EInput_roleNameImage;
     		}
     	}

		public UnityEngine.UI.Image ELoop_RoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoop_RoleImage == null )
     			{
		    		this.m_ELoop_RoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"ELoop_Role");
     			}
     			return this.m_ELoop_RoleImage;
     		}
     	}

		public UnityEngine.UI.LoopHorizontalScrollRect ELoop_RoleLoopHorizontalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoop_RoleLoopHorizontalScrollRect == null )
     			{
		    		this.m_ELoop_RoleLoopHorizontalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopHorizontalScrollRect>(this.uiTransform.gameObject,"ELoop_Role");
     			}
     			return this.m_ELoop_RoleLoopHorizontalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_Ebtn_deleteRoleButton = null;
			this.m_Ebtn_deleteRoleImage = null;
			this.m_Ebtn_createRoleButton = null;
			this.m_Ebtn_createRoleImage = null;
			this.m_Ebtn_startGameButton = null;
			this.m_Ebtn_startGameImage = null;
			this.m_EInput_roleNameInputField = null;
			this.m_EInput_roleNameImage = null;
			this.m_ELoop_RoleImage = null;
			this.m_ELoop_RoleLoopHorizontalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Button m_Ebtn_deleteRoleButton = null;
		private UnityEngine.UI.Image m_Ebtn_deleteRoleImage = null;
		private UnityEngine.UI.Button m_Ebtn_createRoleButton = null;
		private UnityEngine.UI.Image m_Ebtn_createRoleImage = null;
		private UnityEngine.UI.Button m_Ebtn_startGameButton = null;
		private UnityEngine.UI.Image m_Ebtn_startGameImage = null;
		private UnityEngine.UI.InputField m_EInput_roleNameInputField = null;
		private UnityEngine.UI.Image m_EInput_roleNameImage = null;
		private UnityEngine.UI.Image m_ELoop_RoleImage = null;
		private UnityEngine.UI.LoopHorizontalScrollRect m_ELoop_RoleLoopHorizontalScrollRect = null;
		public Transform uiTransform = null;
	}
}
