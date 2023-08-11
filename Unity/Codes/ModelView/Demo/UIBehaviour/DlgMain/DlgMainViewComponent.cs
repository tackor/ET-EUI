
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_CharacterButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CharacterButton == null )
     			{
		    		this.m_E_CharacterButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Character");
     			}
     			return this.m_E_CharacterButton;
     		}
     	}

		public UnityEngine.UI.Image E_CharacterImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CharacterImage == null )
     			{
		    		this.m_E_CharacterImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Character");
     			}
     			return this.m_E_CharacterImage;
     		}
     	}

		public UnityEngine.UI.Text E_RoleLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleLevelText == null )
     			{
		    		this.m_E_RoleLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_RoleLevel");
     			}
     			return this.m_E_RoleLevelText;
     		}
     	}

		public UnityEngine.UI.Text E_GoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_GoldText == null )
     			{
		    		this.m_E_GoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Gold");
     			}
     			return this.m_E_GoldText;
     		}
     	}

		public UnityEngine.UI.Text E_ExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ExpText == null )
     			{
		    		this.m_E_ExpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_Exp");
     			}
     			return this.m_E_ExpText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_CharacterButton = null;
			this.m_E_CharacterImage = null;
			this.m_E_RoleLevelText = null;
			this.m_E_GoldText = null;
			this.m_E_ExpText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_CharacterButton = null;
		private UnityEngine.UI.Image m_E_CharacterImage = null;
		private UnityEngine.UI.Text m_E_RoleLevelText = null;
		private UnityEngine.UI.Text m_E_GoldText = null;
		private UnityEngine.UI.Text m_E_ExpText = null;
		public Transform uiTransform = null;
	}
}
