using System;

namespace ET
{
    [ActorMessageHandler]
    public class A2L_LoginAccountRequestHandler : AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            long accountId = request.AccountId;
            
            //协程锁
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginCenter, accountId.GetHashCode()))
            {
                //登录中心服 查看是否已经登录
                if (!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    reply();
                    return;
                }
                
                //拿到区服
                int zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
                StartSceneConfig gateConfig = RealmGateAddressHelper.GetGate(zone, accountId);
                
                // 从登录中心服务器 发送 一条消息到 Gate网关服务器 通知踢玩家下线
                var g2LDisconnectGateUnit = (G2L_DisconnectGateUnit) await MessageHelper.CallActor(gateConfig.InstanceId, 
                    new L2G_DisconnectGateUnit() { AccountId = accountId });
                response.Error = g2LDisconnectGateUnit.Error;
                reply();
            }
        }
    }
}