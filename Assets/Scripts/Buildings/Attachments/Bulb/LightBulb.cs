using System;
using UnityEngine;
using Zenject;

namespace Buildings.Attachment.Bulb
{
    public class LightBulb : BuildingAttachment
    {
        [SerializeField] private MeshRenderer _bulbMeshRenderer;
        [Inject] private LightBulbColorFactory _factory;
        private BuildingBase _building;

        public override void AttachBuilding(BuildingBase building)
        {
            _building = building;
        }

        public void SetLight(LightBulbType type)
        {
            _bulbMeshRenderer.material = _factory.GetColor(type).Material;
        }
    }
}
