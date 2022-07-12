namespace ET
{
    [FriendClass(typeof (TokenComponent))]
    public static class TokenComponentSystem
    {
        public static void Add(this TokenComponent self, long key, string token)
        {
            self.TokenDict.Add(key, token);
            self.TimeOutRemoveKey(key, token).Coroutine();
        }

        public static string Get(this TokenComponent self, long key)
        {
            string token = null;
            self.TokenDict.TryGetValue(key, out token);
            return token;
        }

        public static void Remove(this TokenComponent self, long key)
        {
            if (self.TokenDict.ContainsKey(key))
            {
                self.TokenDict.Remove(key);
            }
        }

        // 令牌过期检测
        public static async ETTask TimeOutRemoveKey(this TokenComponent self, long key, string token)
        {
            await TimerComponent.Instance.WaitAsync(600000);//10分钟后过期
            string onlinetoken = self.Get(key);
            if (!string.IsNullOrEmpty(onlinetoken) && onlinetoken.Equals(token))
            {
                self.Remove(key);
            }
        }
    }
}