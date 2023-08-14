using UnityEngine;

namespace ET
{
    [FriendClass(typeof(GlobalComponent))]
    public class AfterUnitCreate_CreateUnitView: AEvent<EventType.AfterUnitCreate>
    {
        protected override async ETTask Run(EventType.AfterUnitCreate args)
        {
            // Unit View层
            // 这里可以改成异步加载，demo就不搞了
            await ResourcesComponent.Instance.LoadBundleAsync("Kinight.unit3d");
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset("Kinight.unity3d", "Kinight");
            // GameObject prefab = bundleGameObject.Get<GameObject>("Skeleton");
	        
            GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
            go.transform.SetParent(GlobalComponent.Instance.Unit, true);
            
            args.Unit.AddComponent<GameObjectComponent>().GameObject = go;
            args.Unit.AddComponent<AnimatorComponent>();
            args.Unit.Position = Vector3.zero;
            
            await ETTask.CompletedTask;
        }
    }
}