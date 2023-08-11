using UnityEngine;

namespace ET
{
    public class LoadingBeginEventAsyncCreateLoadingUI : AEvent<EventType.LoadingBegin>
    {
        protected override async ETTask Run(EventType.LoadingBegin args)
        {
            //UIHelper.Create(args.Scene, UIType.UILoading, UILayer.Mid).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
