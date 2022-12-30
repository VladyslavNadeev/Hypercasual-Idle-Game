using Buildings.Storage;
using Items.Container;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemType Type { get => _itemType; }
        public Action<Item> OnDisappear;

        [SerializeField] private ItemType _itemType;
        [SerializeField] private float _itemPositionLerp = 10f;
        [SerializeField] private float _itemRotationLerp = 10f;

        private readonly float _moveEndThreshold = 0.01f;
        private ContainerSlot _currentSlot;

        public void GoToSlot(ItemsContainer container)
        {
            _currentSlot = container.AttachItemToSlot(this);
        }
        public void Disappear()
        {
            OnDisappear?.Invoke(this);
            Destroy(gameObject);
        }

        public void OnSlotAttach(ContainerSlot slot)
        {
            transform.SetParent(slot.transform);
        }
        public void OnSlotDetach(ContainerSlot slot)
        {
            _currentSlot = null;
            transform.SetParent(null);
        }

        private void Update()
        {
            if (_currentSlot == null)
            {
                return;
            }

            moveToSlot();

            float distanceToTarget = Vector3.Distance(transform.position, _currentSlot.transform.position);
            if (distanceToTarget <= _moveEndThreshold)
            {
                transform.position = _currentSlot.transform.position;
                transform.localRotation = Quaternion.identity;
                _currentSlot = null;
            }
        }
        private void moveToSlot()
        {
            transform.position = Vector3.Lerp(
                transform.position,
                _currentSlot.transform.position,
                _itemPositionLerp * Time.deltaTime
                );

            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                _currentSlot.transform.rotation,
                _itemRotationLerp * Time.deltaTime
                );
        }
    }
}
