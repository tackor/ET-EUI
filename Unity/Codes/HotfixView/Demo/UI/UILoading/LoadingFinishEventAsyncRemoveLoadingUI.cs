namespace ET
{
    public class LoadingFinishEventAsyncRemoveLoadingUI : AEvent<EventType.LoadingFinish>
    {
        protected override async ETTask Run(EventType.LoadingFinish args)
        {
            //UIHelper.Create(args.Scene, UIType.UILoading, UILayer.Mid).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
