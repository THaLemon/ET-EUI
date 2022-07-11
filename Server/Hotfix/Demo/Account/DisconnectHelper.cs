namespace ET
{
    public static class DisconnectHelper
    {
        // 针对Session扩展一个异步延迟的断开方法
        public static async ETTask Disconnect(this Session self)
        {
            if (self==null||self.IsDisposed)
            {
                return;
            }

            var instanceId = self.InstanceId;
            await TimerComponent.Instance.WaitAsync(1000);
            if (!instanceId.Equals(self.InstanceId)) // 验证session在此期间没有被修改或释放
            {
                return;
            }
            self.Dispose();
        }
    }
}