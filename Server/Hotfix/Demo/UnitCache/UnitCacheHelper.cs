namespace ET
{
    public static class UnitCacheHelper
    {
        /// <summary>
        /// 保存或更新玩家缓存
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static async ETTask AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
        {
            Other2UnitCache_AddOrUpdateUnit msg = new Other2UnitCache_AddOrUpdateUnit() { UnitId = self.Id };
            msg.EntityTypes.Add(typeof (T).FullName);
            msg.EntityBytes.Add(MongoHelper.ToBson(self));
            await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(self.Id).InstanceId, msg);
        }

        /// <summary>
        /// 获取玩家组件缓存
        /// </summary>
        /// <param name="unitId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async ETTask<T> GetUnitComponentCache<T>(long unitId) where T : Entity, IUnitCache
        {
            Other2UnitCache_GetUnit msg = new Other2UnitCache_GetUnit() { UnitId = unitId };
            msg.ComponentNameList.Add(typeof(T).Name);
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            UnitCache2Other_GetUnit queryUnit = (UnitCache2Other_GetUnit)await MessageHelper.CallActor(instanceId, msg);
            if (queryUnit.Error == ErrorCode.ERR_Success && queryUnit.EntityList.Count > 0)
            {
                return queryUnit.EntityList[0] as T;
            }

            return null;
        }

        /// <summary>
        /// 删除玩家缓存
        /// </summary>
        /// <param name="unitId"></param>
        public static async ETTask DeleteUnitCache(long unitId)
        {
            Other2UnitCache_DeleteUnit msg = new Other2UnitCache_DeleteUnit() { UnitId = unitId };
            long instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            await MessageHelper.CallActor(instanceId, msg);
        }
    }
}