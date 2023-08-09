using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof(DlgRoles))]
    [FriendClassAttribute(typeof(ET.RoleInfosComponent))]
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    public static class DlgRolesSystem
    {

        public static void RegisterUIEvent(this DlgRoles self)
        {
            self.View.E_StartGameButton.AddListenerAsync(() => { return self.OnStartGameClickHandler(); });
            self.View.E_CreateRoleButton.AddListenerAsync(() => { return self.OnCreateRoleClickHandler(); });
            self.View.E_DeleteRoleButton.AddListenerAsync(() => { return self.OnDeleteRoleClickHandler(); });
            self.View.E_RoleListLoopVerticalScrollRect.AddItemRefreshListener((transform, i) =>
            {
                self.OnRoleListRefreshHandler(transform, i);
            });
        }

        public static void ShowWindow(this DlgRoles self, Entity contextData = null)
        {
            self.RefreshRoleItems();
        }

        public static void RefreshRoleItems(this DlgRoles self)
        {
            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoles, count);
            self.View.E_RoleListLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
        {
            Scroll_Item_Role item = self.ScrollItemRoles[index].BindTrans(transform);
            RoleInfo info = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];

            item.EImage_SelectImage.color = info.Id == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId ? Color.green : Color.gray;
            item.EText_RoleNameText.SetText(info.Name);
            item.EButton_SelectButton.AddListener(() => { self.OnRoleItemClickHandler(info.Id);});
        }

        public static void OnRoleItemClickHandler(this DlgRoles self, long roleId)
        {
            self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = roleId;
            self.View.E_RoleListLoopVerticalScrollRect.RefillCells();
        }

        public static async ETTask OnStartGameClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择需要登录的角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRealmKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                errorCode = await LoginHelper.EnterGame(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                
                self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Roles);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnCreateRoleClickHandler(this DlgRoles self)
        {
            string name = self.View.E_RoleNameInputField.text;
            if (string.IsNullOrEmpty(name))
            {
                Log.Error("Name is null");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

        public static async ETTask OnDeleteRoleClickHandler(this DlgRoles self)
        {
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择需要删除的角色");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }
                self.RefreshRoleItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }

            await ETTask.CompletedTask;
        }
    }
}
