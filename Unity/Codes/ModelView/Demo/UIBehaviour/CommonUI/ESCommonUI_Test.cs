
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESCommonUI_Test : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EImage_Test1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImage_Test1Image == null )
     			{
		    		this.m_EImage_Test1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImage_Test1");
     			}
     			return this.m_EImage_Test1Image;
     		}
     	}

		public UnityEngine.UI.Text EText_Test2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EText_Test2Text == null )
     			{
		    		this.m_EText_Test2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EText_Test2");
     			}
     			return this.m_EText_Test2Text;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImage_Test1Image = null;
			this.m_EText_Test2Text = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_EImage_Test1Image = null;
		private UnityEngine.UI.Text m_EText_Test2Text = null;
		public Transform uiTransform = null;
	}
}
