using System;

namespace ET.Numeric.Handler
{
    public class C2M_TestUnitNumericHandler : AMActorLocationRpcHandler<Unit, C2M_TestUnitNumeric, M2C_TestUnitNumeric>
    {
        protected override async ETTask Run(Unit unit, C2M_TestUnitNumeric request, M2C_TestUnitNumeric response, Action reply)
        {
            //这里的 unit 可以直接理解为 游戏客户端在我们Map游戏逻辑服中的映射
            NumericComponent numericComponent = unit.GetComponent<NumericComponent>();

            int newGold = numericComponent.GetAsInt(NumericType.Gold) + 100;
            long neweExp = numericComponent.GetAsLong(NumericType.Exp) + 50;
            long newLevel = numericComponent.GetAsLong(NumericType.Level) + 1;
            numericComponent.Set(NumericType.Gold, newGold);
            numericComponent.Set(NumericType.Exp, neweExp);
            numericComponent.Set(NumericType.Level, newLevel);

            reply();
            
            await ETTask.CompletedTask;
        }
    }
}