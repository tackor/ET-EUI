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
 
        public const int ERR_NetWorkError                   = 200002;  //网络错误
        public const int ERR_LoginInfoIsNull                = 200003;  //登录信息错误
        public const int ERR_AccountNameFormError           = 200004;  //登录账号格式错误
        public const int ERR_PasswordFormError              = 200005;  //登录密码格式错误
        public const int ERR_AccountInBlackListError        = 200006;  //账号处于黑名单中
        public const int ERR_LoginPasswordError             = 200007;  //登录密码错误
        public const int ERR_RequestRepeatedly              = 200008;
        public const int ERR_TokenError                     = 200009;

        public const int ERR_RoleNameIsNull = 200010;   //游戏角色名称为空
        public const int ERR_RoleNameSame = 200011;     //游戏角色同名
        public const int ERR_RoleNotExist = 200012;     //游戏角色不存在
        
        public const int ERR_ConnectGateKeyError = 200014;  //连接Gate的令牌错误
        public const int ERR_RequestSceneTypeError = 200015;  //请求的Scene错误
        public const int ERR_OtherAccountLogin = 200016;  //其他账号登录

        public const int ERR_SessionPlayerError = 200017;
        public const int ERR_NonePlayerError = 200018;
        public const int ERR_PlayerSessionError = 200019;
        public const int ERR_SessionStateError = 200020;

        public const int ERR_EnterGameError = 200021;
        public const int ERR_ReEnterGameError = 200022;
        public const int ERR_ReEnterGameError2 = 200023;
        
        public const int ERR_NumericTypeNotExist = 200024;
        public const int ERR_NumericTypeNotAddPoint = 200025;
        public const int ERR_AddPointNotEnough = 200026;
        
        public const int ERR_AlreadyAdventureState = 200027;
        public const int ERR_AdventureInDying = 200028;
        public const int ERR_AdventureErrorLevel = 200029;
        public const int ERR_AdventureLevelNotEnough = 200030;
    }
}