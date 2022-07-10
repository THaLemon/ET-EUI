using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof (DlgRedDot))]
	public static class DlgRedDotSystem
	{
		public static void RegisterUIEvent(this DlgRedDot self)
		{
			self.View.E_MailNode1Button.AddListener(() => { self.OnMailNode1ClickHandler(); });
			self.View.E_MailNode2Button.AddListener(() => { self.OnMailNode2ClickHandler(); });
			self.View.E_BagNode1Button.AddListener(() => { self.OnBagNode1ClickHandler(); });
			self.View.E_BagNode2Button.AddListener(() => { self.OnBagNode2ClickHandler(); });
		}

		public static void ShowWindow(this DlgRedDot self, Entity contextData = null)
		{
			var view = self.View;
			// 建立逻辑关系
			RedDotHelper.AddRedDotNode(self.ZoneScene(), "Root", view.E_rootButton.name, true);

			RedDotHelper.AddRedDotNode(self.ZoneScene(), view.E_rootButton.name, view.E_BagButton.name, true);
			RedDotHelper.AddRedDotNode(self.ZoneScene(), view.E_rootButton.name, view.E_MailButton.name, true);

			RedDotHelper.AddRedDotNode(self.ZoneScene(), view.E_BagButton.name, view.E_BagNode1Button.name, true);
			RedDotHelper.AddRedDotNode(self.ZoneScene(), view.E_BagButton.name, view.E_BagNode2Button.name, true);
			RedDotHelper.AddRedDotNode(self.ZoneScene(), view.E_MailButton.name, view.E_MailNode1Button.name, true);
			RedDotHelper.AddRedDotNode(self.ZoneScene(), view.E_MailButton.name, view.E_MailNode2Button.name, true);

			// 添加显示关系
			var redDotMonoView = view.E_rootButton.GetComponent<RedDotMonoView>();
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_rootButton.name, redDotMonoView);

			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_BagButton.name, view.E_BagButton.gameObject, Vector3.one, Vector3.zero);
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_BagNode1Button.name, view.E_BagNode1Button.gameObject, Vector3.one, Vector3.zero);
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_BagNode2Button.name, view.E_BagNode2Button.gameObject, Vector3.one, Vector3.zero);

			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_MailButton.name, view.E_MailButton.gameObject, Vector3.one, Vector3.zero);
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_MailNode1Button.name, view.E_MailNode1Button.gameObject, Vector3.one,
				Vector3.zero);
			RedDotHelper.AddRedDotNodeView(self.ZoneScene(), view.E_MailNode2Button.name, view.E_MailNode2Button.gameObject, Vector3.one,
				Vector3.zero);

			// 设置显示所有子叶节点
			RedDotHelper.ShowRedDotNode(self.ZoneScene(), view.E_BagNode1Button.name);
			RedDotHelper.ShowRedDotNode(self.ZoneScene(), view.E_BagNode2Button.name);
			RedDotHelper.ShowRedDotNode(self.ZoneScene(), view.E_MailNode1Button.name);
			RedDotHelper.ShowRedDotNode(self.ZoneScene(), view.E_MailNode2Button.name);

			// 刷新指定的子叶节点
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), view.E_BagNode1Button.name, self.RedDotBagCount1);
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), view.E_BagNode2Button.name, self.RedDotBagCount2);
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), view.E_MailNode1Button.name, self.RedDotMailCount1);
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), view.E_MailNode2Button.name, self.RedDotMailCount2);
		}

		public static void OnBagNode1ClickHandler(this DlgRedDot self)
		{
			self.RedDotBagCount1 += 1;
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), self.View.E_BagNode1Button.name, self.RedDotBagCount1);
		}

		public static void OnBagNode2ClickHandler(this DlgRedDot self)
		{
			self.RedDotBagCount2 += 1;
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), self.View.E_BagNode2Button.name, self.RedDotBagCount2);
		}


		public static void OnMailNode1ClickHandler(this DlgRedDot self)
		{
			self.RedDotMailCount1 += 1;
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), self.View.E_MailNode1Button.name, self.RedDotMailCount1);
		}

		public static void OnMailNode2ClickHandler(this DlgRedDot self)
		{
			self.RedDotMailCount2 += 1;
			RedDotHelper.RefreshRedDotViewCount(self.ZoneScene(), self.View.E_MailNode2Button.name, self.RedDotMailCount2);

		}
	}
}