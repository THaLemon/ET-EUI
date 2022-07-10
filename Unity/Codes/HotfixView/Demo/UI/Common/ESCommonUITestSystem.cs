namespace ET
{
    public static class ESCommonUITestSystem
    {
        public static void SetLabelContent(this ESCommonUI_Test self, string message)
        {
            self.ELabel_Text.text = "狗屁文本";
            self.EButton_CommonUI_TestButton.AddListener(self.OnTestButtonClickhandler);
        }

        public static void OnTestButtonClickhandler(this ESCommonUI_Test self)
        {
            Log.Debug("狗屁按钮 Click");
        }
    }
}