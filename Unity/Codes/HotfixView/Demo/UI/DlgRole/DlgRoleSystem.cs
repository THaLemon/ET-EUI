using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof (DlgRole))]
	[FriendClass(typeof (RoleInfosComponent))]
	[FriendClass(typeof (RoleInfo))]
	public static class DlgRoleSystem
	{

		public static void RegisterUIEvent(this DlgRole self)
		{
			// AddListenerAsync 异步的监听方法,在服务器返回消息前等待,按钮不可操作
			self.View.Ebtn_createRoleButton.AddListenerAsync(() => { return self.OnCreateRoleClickHandler(); });
			self.View.Ebtn_deleteRoleButton.AddListenerAsync(() => { return self.OnDeleteRoleClickHandler(); });
			self.View.Ebtn_startGameButton.AddListenerAsync(() => { return self.OnStartGameClickHandler(); });
			self.View.ELoop_ServerLoopHorizontalScrollRect.AddItemRefreshListener((Transform trans, int index) =>
			{
				self.OnScrollItemRefreshHandler(trans, index);
			});
		}

		public static void ShowWindow(this DlgRole self, Entity contextData = null)
		{
			self.RefreshRoleItem();
		}

		public static void RefreshRoleItem(this DlgRole self)
		{
			int count = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos.Count;
			self.AddUIScrollItems(ref self.Scroll_Item_Role_Dict, count);
			self.View.ELoop_ServerLoopHorizontalScrollRect.SetVisible(true, count);
		}

		public static void HideWindow(this DlgRole self, Entity contextData = null)
		{
			self.RemoveUIScrollItems(ref self.Scroll_Item_Role_Dict);
		}

		public static void OnScrollItemRefreshHandler(this DlgRole self, Transform trans, int index)
		{
			var serverItem = self.Scroll_Item_Role_Dict[index].BindTrans(trans);
			RoleInfo info = self.ZoneScene().GetComponent<RoleInfosComponent>().RoleInfos[index];
			serverItem.Ebtn_chooseImage.color =
					info.Id == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId? Color.red : Color.cyan;
			serverItem.Elb_roleNameText.SetText(info.Name);
			serverItem.Ebtn_chooseButton.AddListener(() => { self.onSelectServerItemHandler(info.Id); });

		}

		public static void onSelectServerItemHandler(this DlgRole self, long serverId)
		{
			self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
			Log.Debug($"当前所选的服务器ID是: {serverId}");
			// 主动刷新 循环列表项
			self.View.ELoop_ServerLoopHorizontalScrollRect.RefillCells();
		}

		public static async ETTask OnCreateRoleClickHandler(this DlgRole self)
		{
			string roleName = self.View.EInput_roleNameInputField.text;
			if (string.IsNullOrEmpty(roleName))
			{
				Log.Debug("name is null!");
				return;
			}

			try
			{
				int error = await LoginHelper.CreateRole(self.ZoneScene(), roleName);
				if (error != ErrorCode.ERR_Success)
				{
					Log.Error(error.ToString());
					return;
				}

				self.RefreshRoleItem();
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				return;
			}
			await ETTask.CompletedTask;
		}

		public static async ETTask OnDeleteRoleClickHandler(this DlgRole self)
		{
			if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId==0)
			{
				Log.Debug("请先选择要删除的角色!");
				return;
			}

			try
			{
				int error = await LoginHelper.DeleteRole(self.ZoneScene());
				if (error != ErrorCode.ERR_Success)
				{
					Log.Error(error.ToString());
					return;
				}

				self.RefreshRoleItem();
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				return;
			}
			await ETTask.CompletedTask;
		}

		public static async ETTask OnStartGameClickHandler(this DlgRole self)
		{
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Lobby);
			self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Role);
		}
	}
}