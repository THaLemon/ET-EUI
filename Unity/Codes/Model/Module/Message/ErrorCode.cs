namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误

        // 110000以下的错误请看ErrorCore.cs

        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
        public const int ERR_NetWorkError = 200002;                 //网络错误
        public const int ERR_LoginInfoError = 200003;               //登录信息错误
        public const int ERR_AccountNameError = 200004;             //账户名错误
        public const int ERR_AccountPasswordFormatError = 200005;   //密码格式错误
        public const int ERR_AccountPasswordError = 200006;         //密码错误
        public const int ERR_AccountInBlackListError = 200007;      //账户在黑名单中
        public const int ERR_RequestRepeatly  = 200008;             //重复请求
        
        public const int ERR_TokenError  = 200009;                  //令牌错误
        public const int ERR_RoleNameIsEmptyError  = 200010;        //角色名字错误
        public const int ERR_RoleNameIsRepeatedError  = 200011;     //角色名字重复
    }
}