using Buildings.Attachment.Bulb;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings.ProductionBuilding.States
{
    public class SuspendedState : ProductionStateBase
    {
        private ProductionBuilding _building;

        public override void Enter(ProductionBuilding building)
        {
            _building = building;

            IReadOnlyCollection<LightBulb> outLightBulb;
            if (!_building.GetAttachment(out outLightBulb))
                return;

            foreach (LightBulb bulb in outLightBulb)
            {
                bulb.SetLight(LightBulbType.Yellow);
            }
        }

        public override void Update()
        {
            if (_building.CanCraft())
            {
                _building.SwitchState(_building.WorkingState);
            }
        }
    }
}
