using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [FriendClass(typeof(DlgTest))]
    public static class DlgTestSystem
    {

        public static void RegisterUIEvent(this DlgTest self)
        {
            self.View.EButton_TestButton.AddListener(() => { self.OnTestButtonClickhandler(); });
            self.View.ELoopScrollList_TestLoopHorizontalScrollRect.AddItemRefreshListener((Transform pos, int index) => { self.OnLoopListItemRefresh(pos, index); });
        }

        public static void ShowWindow(this DlgTest self, Entity contextData = null)
        {
            self.View.EText_TestText.text = "测试文本框";
            // 初始化循环列表
            const int count = 25;
            self.AddUIScrollItems(ref self.Scroll_Item_testDict, count);
            self.View.ELoopScrollList_TestLoopHorizontalScrollRect.SetVisible(true, count);
        }
        public static void HideWindow(this DlgTest self, Entity contextData = null)
        {
            self.RemoveUIScrollItems(ref self.Scroll_Item_testDict);
        }

        public static void OnTestButtonClickhandler(this DlgTest self)
        {
            Log.Debug("测试按钮 Click");
        }

        public static void OnLoopListItemRefresh(this DlgTest self, Transform pos, int index)
        {
            var item = self.Scroll_Item_testDict[index].BindTrans(pos);
            item.ELabel_TestText.text = $"{index + 1}服";
        }
    }
}