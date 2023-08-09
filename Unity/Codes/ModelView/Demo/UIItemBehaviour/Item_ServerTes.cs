
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_ServerTes : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_ServerTes BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EImage_ServerTesImage
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
     				if( this.m_EImage_ServerTesImage == null )
     				{
		    			this.m_EImage_ServerTesImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_ServerTes");
     				}
     				return this.m_EImage_ServerTesImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_ServerTes");
     			}
     		}
     	}

		public UnityEngine.UI.Text EText_ServerTesText
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
     				if( this.m_EText_ServerTesText == null )
     				{
		    			this.m_EText_ServerTesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText_ServerTes");
     				}
     				return this.m_EText_ServerTesText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText_ServerTes");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_ServerTesImage = null;
			this.m_EText_ServerTesText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EImage_ServerTesImage = null;
		private UnityEngine.UI.Text m_EText_ServerTesText = null;
		public Transform uiTransform = null;
	}
}
