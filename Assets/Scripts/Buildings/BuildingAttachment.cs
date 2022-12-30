using System;
using UnityEngine;

namespace Buildings.Attachment
{
    public abstract class BuildingAttachment : MonoBehaviour
    {
        public abstract void AttachBuilding(BuildingBase building);
    }
}
