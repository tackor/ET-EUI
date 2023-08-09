
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_DeleteRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteRoleButton == null )
     			{
		    		this.m_E_DeleteRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_DeleteRole");
     			}
     			return this.m_E_DeleteRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_DeleteRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DeleteRoleImage == null )
     			{
		    		this.m_E_DeleteRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_DeleteRole");
     			}
     			return this.m_E_DeleteRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_CreateRoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleButton == null )
     			{
		    		this.m_E_CreateRoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleButton;
     		}
     	}

		public UnityEngine.UI.Image E_CreateRoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CreateRoleImage == null )
     			{
		    		this.m_E_CreateRoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_CreateRole");
     			}
     			return this.m_E_CreateRoleImage;
     		}
     	}

		public UnityEngine.UI.Button E_StartGameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameButton == null )
     			{
		    		this.m_E_StartGameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/E_StartGame");
     			}
     			return this.m_E_StartGameButton;
     		}
     	}

		public UnityEngine.UI.Image E_StartGameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartGameImage == null )
     			{
		    		this.m_E_StartGameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_StartGame");
     			}
     			return this.m_E_StartGameImage;
     		}
     	}

		public UnityEngine.UI.InputField E_RoleNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameInputField == null )
     			{
		    		this.m_E_RoleNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"Sprite_BackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_RoleNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleNameImage == null )
     			{
		    		this.m_E_RoleNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/E_RoleName");
     			}
     			return this.m_E_RoleNameImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RoleListLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RoleListLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RoleListLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/E_RoleList");
     			}
     			return this.m_E_RoleListLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_DeleteRoleButton = null;
			this.m_E_DeleteRoleImage = null;
			this.m_E_CreateRoleButton = null;
			this.m_E_CreateRoleImage = null;
			this.m_E_StartGameButton = null;
			this.m_E_StartGameImage = null;
			this.m_E_RoleNameInputField = null;
			this.m_E_RoleNameImage = null;
			this.m_E_RoleListLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_DeleteRoleButton = null;
		private UnityEngine.UI.Image m_E_DeleteRoleImage = null;
		private UnityEngine.UI.Button m_E_CreateRoleButton = null;
		private UnityEngine.UI.Image m_E_CreateRoleImage = null;
		private UnityEngine.UI.Button m_E_StartGameButton = null;
		private UnityEngine.UI.Image m_E_StartGameImage = null;
		private UnityEngine.UI.InputField m_E_RoleNameInputField = null;
		private UnityEngine.UI.Image m_E_RoleNameImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RoleListLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
