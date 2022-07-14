using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ET
{
	public static class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.E_LoginButton.AddListenerAsync(() => { return self.OnLoginClickHandler(); });
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{

		}

		public static async ETTask OnLoginClickHandler(this DlgLogin self)
		{
			try
			{
				int error = await LoginHelper.Login(self.DomainScene(),
					ConstValue.LoginAddress,
					self.View.E_AccountInputField.GetComponent<InputField>().text,
					self.View.E_PasswordInputField.GetComponent<InputField>().text);
				if (error != ErrorCode.ERR_Success)
				{
					Log.Error(error.ToString());
					return;
				}

				error = await LoginHelper.GetServerInfos(self.ZoneScene());
				if (error != ErrorCode.ERR_Success)
				{
					Log.Error(error.ToString());
					return;
				}

				// Todo:登陆成功后的显示逻辑
				self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
				self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Server);
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
				return;
			}
		}

		public static void HideWindow(this DlgLogin self)
		{

		}
	}
}