using Interactable;
using Items;
using Items.Container;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

namespace Buildings.Storage
{
    public class StoragePad : MonoBehaviour, IInteractable
    {
        public ItemsContainer ItemsContainer { get => _itemsContainer; }
        public StorageBuildingType Type { get => _storageType; }
        public float InteractionRadius { get => _interactionRadius; }
        public ItemType ItemType { get => _itemType; }


        [SerializeField] private StorageBuildingType _storageType;
        [SerializeField] private ItemsContainer _itemsContainer;
        [SerializeField] private float _interactionRadius = 1.5f;
        [SerializeField] private ItemType _itemType;


        [Inject] private Interactables _interactables;

        public void Interact(Player.Player player)
        {
            switch (_storageType)
            {
                case StorageBuildingType.Input:
                    takeItemsFromPlayer(player);
                    break;
                case StorageBuildingType.Output:
                    giveItemsToPlayer(player);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        private void giveItemsToPlayer(Player.Player player)
        {
            if (ItemsContainer.Count == 0)
                return;

            if (!player.Backpack.ItemsContainer.CanAddItem())
                return;

            Item takenItem = null;
            if (!ItemsContainer.TakeItem(out takenItem))
                return;

            player.Backpack.ItemsContainer.AddItem(takenItem);
        }
        private void takeItemsFromPlayer(Player.Player player)
        {
            if (!ItemsContainer.CanAddItem())
                return;

            Item takenItem = null;
            if (!player.Backpack.ItemsContainer.TakeItem(out takenItem, ItemType))
                return;

            ItemsContainer.AddItem(takenItem);
        }

        public void Register()
        {
            _interactables.Register(this);
        }
        public void Unregister()
        {
            _interactables.Unregister(this);
        }

        private void Awake()
        {
            _itemsContainer.Init(_itemType);
            Register();
        }
        private void OnDestroy()
        {
            Unregister();
        }      
    }
}
