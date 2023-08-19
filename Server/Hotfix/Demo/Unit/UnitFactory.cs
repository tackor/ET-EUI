﻿using System;
using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
                    foreach (var config in PlayerNumericConfigCategory.Instance.GetAll())
                    {
                        if (config.Value.BaseValue == 0)
                        {
                            continue;
                        }

                        if (config.Key < 3000) //小于3000的值都用加成属性推导
                        {
                            int baseKey = config.Key * 10 + 1;
                            numericComponent.SetNoEvent(baseKey, config.Value.BaseValue);
                        }
                        else
                        {
                            //大于3000的值, 直接使用
                            numericComponent.SetNoEvent(config.Key, config.Value.BaseValue);
                        }
                    }
                    
                    unitComponent.Add(unit);
                    // 加入aoi
                    // unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}