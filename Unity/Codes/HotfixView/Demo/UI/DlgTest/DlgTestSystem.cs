using System.Diagnostics;
using UnityEngine;

namespace ET
{
	[FriendClass(typeof(DlgTest))]
	public static  class DlgTestSystem
	{

		public static void RegisterUIEvent(this DlgTest self)
		{
			self.View.E_EnterMapButton.AddListener(self.OnEnterMapClickHandler);
			self.View.ELoopScrollList_TestLoopHorizontalScrollRect.AddItemRefreshListener(
				(Transform transform, int index) =>
				{
					self.OnLoopListItemRefreshHandler(transform, index);
				});
		}

		public static void ShowWindow(this DlgTest self, Entity contextData = null)
		{
			self.View.EText_TestText.text = "修改 Test 文本";
			self.View.ESCommonUI_Test.SetLabelContent("测试页面");

			int count = 100;
			self.AddUIScrollItems(ref self.ScrollItemServerTestDict, count);
			self.View.ELoopScrollList_TestLoopHorizontalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgTest self)
		{
			self.RemoveUIScrollItems(ref self.ScrollItemServerTestDict);
		}

		public static void OnEnterMapClickHandler(this DlgTest self)
		{
			Log.Debug("测试按钮被点击了 !");
		}

		public static void OnLoopListItemRefreshHandler(this DlgTest self, Transform transform, int index)
		{
			Scroll_Item_ServerTes item = self.ScrollItemServerTestDict[index].BindTrans(transform);
			item.EText_ServerTesText.text = $"{index} 服";
		}
	}
}











