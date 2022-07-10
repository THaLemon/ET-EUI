
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Test_Rum : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Test_Rum BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EImage_TestImage
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
     				if( this.m_EImage_TestImage == null )
     				{
		    			this.m_EImage_TestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Test");
     				}
     				return this.m_EImage_TestImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Test");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_TestText
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
     				if( this.m_ELabel_TestText == null )
     				{
		    			this.m_ELabel_TestText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Test");
     				}
     				return this.m_ELabel_TestText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Test");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_TestImage = null;
			this.m_ELabel_TestText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_TestImage = null;
		private UnityEngine.UI.Text m_ELabel_TestText = null;
		public Transform uiTransform = null;
	}
}
