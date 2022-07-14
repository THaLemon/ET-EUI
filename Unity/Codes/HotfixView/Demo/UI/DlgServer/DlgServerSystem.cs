using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof (DlgServer))]
	[FriendClass(typeof (ServerInfosComponent))]
	[FriendClass(typeof (ServerInfo))]
	public static class DlgServerSystem
	{

		public static void RegisterUIEvent(this DlgServer self)
		{
			// AddListenerAsync 异步的监听方法,在服务器返回消息前等待,按钮不可操作
			self.View.Ebtn_chooseButton.AddListenerAsync(() => { return self.OnConfirmClickHandler(); });
			self.View.ELoop_ServerLoopVerticalScrollRect.AddItemRefreshListener((Transform trans, int index) =>
			{
				self.OnScrollItemRefreshHandler(trans, index);
			});
		}

		public static void ShowWindow(this DlgServer self, Entity contextData = null)
		{
			int count = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList.Count;
			self.AddUIScrollItems(ref self.Scroll_Item_Server_Dict, count);
			self.View.ELoop_ServerLoopVerticalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgServer self, Entity contextData = null)
		{
			self.RemoveUIScrollItems(ref self.Scroll_Item_Server_Dict);
		}


		public static void OnScrollItemRefreshHandler(this DlgServer self, Transform trans, int index)
		{
			var serverItem = self.Scroll_Item_Server_Dict[index].BindTrans(trans);
			ServerInfo info = self.ZoneScene().GetComponent<ServerInfosComponent>().ServerInfoList[index];
			serverItem.Ebtn_chooseImage.color =
					info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId? Color.red : Color.cyan;
			serverItem.Elbl_serverNameText.SetText(info.ServerName);
			serverItem.Ebtn_chooseButton.AddListener(() => { self.onSelectServerItemHandler(info.Id); });

		}

		public static void onSelectServerItemHandler(this DlgServer self, long serverId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
			Log.Debug($"当前所选的服务器ID是: {serverId}");
			// 主动刷新 循环列表项
			self.View.ELoop_ServerLoopVerticalScrollRect.RefillCells();
		}

		public static async ETTask OnConfirmClickHandler(this DlgServer self)
		{
			bool isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;
			if (!isSelect)
			{
				Log.Debug("请先选择区服!");
				return;
			}

			try
			{
				int error = await LoginHelper.GetRole(self.ZoneScene());
				if (error != ErrorCode.ERR_Success)
				{
					Log.Error(error.ToString());
					return;
				}

				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Role);
				self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				return;
			}
		}
	}
}