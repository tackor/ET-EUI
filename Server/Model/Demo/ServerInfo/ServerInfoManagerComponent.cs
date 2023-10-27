using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(ServerInfo))]
    [ComponentOf(typeof(Scene))]
    public class ServerInfoManagerComponent : Entity, IAwake, IDestroy, ILoad
    {
        public List<ServerInfo> ServerInfos = new List<ServerInfo>();
    }
}