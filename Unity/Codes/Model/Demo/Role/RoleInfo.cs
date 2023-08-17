namespace ET
{
    public enum RoleInfoState
    {
        Normal,
        Freeze,
    }
    
    [ComponentOf]
    public class RoleInfo : Entity, IAwake
    {
        public string Name;
        public int ServerId;
        public int State;
        public long AccountId;
        public long LastLoginTime;
        public long CreateTime;
    }
}