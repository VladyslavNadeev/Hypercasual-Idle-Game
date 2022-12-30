using Buildings.Attachment;
using Buildings.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Buildings
{
    public abstract class BuildingBase : MonoBehaviour
    {
        public IReadOnlyCollection<StoragePad> InputStoragePads
        {
            get
            {
                return _storagePads.Where(x => x.Type == StorageBuildingType.Input).ToList().AsReadOnly();
            }
        }
        public StoragePad OutputStoragePad
        {
            get
            {
                return _storagePads.Where(x => x.Type == StorageBuildingType.Output).First();
            }
        }
        public IReadOnlyCollection<BuildingAttachment> Attachments
        {
            get
            {
                return _attachments.ToList().AsReadOnly();
            }
        }

        protected BuildingProductionTimer ProductionTimer { get => _productionTimer; }

        [SerializeField] private BuildingAttachment[] _attachments;
        [SerializeField] private StoragePad[] _storagePads;
        private BuildingProductionTimer _productionTimer = new BuildingProductionTimer();

        public bool GetAttachment<T>(out IReadOnlyCollection<T> attachment)
        {
            IReadOnlyCollection<T> foundAttachments = Attachments.OfType<T>().ToList().AsReadOnly();

            if (foundAttachments.Count == 0)
            {
                attachment = foundAttachments;
                return false;
            }

            attachment = foundAttachments.ToList().AsReadOnly();
            return true;
        }

        private void Awake()
        {
            foreach (BuildingAttachment attachment in Attachments)
            {
                attachment.AttachBuilding(this);
            }
        }
        private void OnDestroy()
        {
            _productionTimer.Stop();
        }
    }
}