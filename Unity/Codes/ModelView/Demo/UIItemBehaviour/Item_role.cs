
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_role : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_role BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
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
     			if (this.isCacheNode)
     			{
     				if( this.m_Ebtn_chooseButton == null )
     				{
		    			this.m_Ebtn_chooseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_choose");
     				}
     				return this.m_Ebtn_chooseButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Ebtn_choose");
     			}
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
     			if (this.isCacheNode)
     			{
     				if( this.m_Ebtn_chooseImage == null )
     				{
		    			this.m_Ebtn_chooseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_choose");
     				}
     				return this.m_Ebtn_chooseImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Ebtn_choose");
     			}
     		}
     	}

		public UnityEngine.UI.Text Elb_roleNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_Elb_roleNameText == null )
     				{
		    			this.m_Elb_roleNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Elb_roleName");
     				}
     				return this.m_Elb_roleNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Elb_roleName");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_Ebtn_chooseButton = null;
			this.m_Ebtn_chooseImage = null;
			this.m_Elb_roleNameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_Ebtn_chooseButton = null;
		private UnityEngine.UI.Image m_Ebtn_chooseImage = null;
		private UnityEngine.UI.Text m_Elb_roleNameText = null;
		public Transform uiTransform = null;
	}
}
