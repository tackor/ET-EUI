using System.Collections;
using System.Collections.Generic;
using System;
using CommandLine;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof(DlgServer))]
    [FriendClassAttribute(typeof(ET.ServerInfosComponent))]
    [FriendClassAttribute(typeof(ET.ServerInfo))]
    public static class DlgServerSystem
    {

        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.E_SelectServerButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
            self.View.E_ServerListLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
            {
                self.OnScrollItemRefreshHandler(transform, index);
            });
        }

        public static void ShowWindow(this DlgServer self, Entity contextData = null)
        {
            int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
            self.AddUIScrollItems(ref self.ScrollItemRoles, count);
            self.View.E_ServerListLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void HideWindow(this DlgServer self)
        {
            self.RemoveUIScrollItems(ref self.ScrollItemRoles);
        }

        public static void OnScrollItemRefreshHandler(this DlgServer self, Transform transform, int index)
        {
            Scroll_Item_Server item = self.ScrollItemRoles[index].BindTrans(transform);
            ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
            item.EText_ServerNameText.SetText(info.ServerName);
            item.EImage_SelectImage.color = info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId ? Color.red : Color.cyan;
            item.EButton_SelectButton.AddListener(() => { self.OnSelectServerClickHandler(info.Id); });
        }

        public static void OnSelectServerClickHandler(this DlgServer self, long serverId)
        {
            self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
            Log.Debug($"当前选择的服务器 Id 是: {serverId}");
            self.View.E_ServerListLoopVerticalScrollRect.RefillCells();
        }

        public static async ETTask OnConfirmClickHandler(this DlgServer self)
        {
            bool isSelected = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
            if (!isSelected)
            {
                Log.Error("请先选择区服");
                return;
            }

            try
            {
                int errorCode = await LoginHelper.GetRoles(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Roles);
                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}
