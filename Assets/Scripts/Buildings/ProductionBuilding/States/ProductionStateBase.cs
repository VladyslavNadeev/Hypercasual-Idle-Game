using System;
using UnityEngine;

namespace Buildings.ProductionBuilding.States
{
    public abstract class ProductionStateBase
    {
        public abstract void Enter(ProductionBuilding building);
        public abstract void Update();
    }
}
