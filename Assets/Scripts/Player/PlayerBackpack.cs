using Buildings.Storage;
using Interactable;
using Items;
using Items.Container;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Player
{
    [RequireComponent(typeof(Player))]
    public class PlayerBackpack : MonoBehaviour
    {
        public ItemsContainer ItemsContainer { get => _itemsContainer; }

        [SerializeField] private Transform _interactOrigin;
        [SerializeField] private ItemsContainer _itemsContainer;

        [Inject] private Interactables _interactables;
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _itemsContainer.Init(ItemType.Null);
        }
        private void Update()
        {
            tryToInteract();
        }
        private void tryToInteract()
        {
            IReadOnlyCollection<StoragePad> interactablePads = _interactables
                .GetInteractables<StoragePad>(_interactOrigin.position)
                .ToList()
                .AsReadOnly();

            foreach (StoragePad pad in interactablePads)
            {
                pad.Interact(_player);
            }
        }
    }
}
