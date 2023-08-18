﻿namespace ET
{
    
    public class SceneChangeFinish_ShowCurrentSceneUI: AEventAsync<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            // args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Lobby);
            args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Loading);
            await ETTask.CompletedTask;
        }
    }
    
}