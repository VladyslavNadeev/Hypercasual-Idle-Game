using Buildings.ProductionBuilding.States;
using Buildings.Storage;
using Items;
using Items.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Buildings.ProductionBuilding
{
    public class ProductionBuilding : BuildingBase
    {
        public Recipe Recipe { get => _recipe; }
        public WorkingState WorkingState { get => _workingState; }
        public SuspendedState SuspendedState { get => _suspendedState; }

        [SerializeField] private Recipe _recipe;
        [Space]
        [SerializeField] private Transform _inputPoint;
        [SerializeField] private Transform _outputPoint;

        [Inject] private ItemsFactory _itemsFactory;

        private ProductionStateBase _currentState;
        private WorkingState _workingState = new WorkingState();
        private SuspendedState _suspendedState = new SuspendedState();

        public bool CanCraft()
        {
            if (_recipe.InputItems.Count == 0)
                return true;

            if (_recipe.InputItems.Count != InputStoragePads.Count)
            {
                Debug.Log($"Count of Recipe Inputs and Input StoragePads doesn't match!");
                return false;
            }

            List<StoragePad> validPads = new List<StoragePad>();

            foreach (ItemType item in _recipe.InputItems)
            {
                foreach (StoragePad pad in InputStoragePads)
                {
                    if (pad.ItemType == item && pad.ItemsContainer.Count == 0)
                        continue;

                    validPads.Add(pad);
                }
            }

            if (validPads.Count < _recipe.InputItems.Count)
                return false;

            return true;
        }
        public void SwitchState(ProductionStateBase state)
        {
            _currentState = state;
            _currentState.Enter(this);
        }

        private void Start()
        {
            ProductionTimer.TickTime = _recipe.ProductionTime;
            ProductionTimer.Ticked += produce;
            ProductionTimer.Start();

            SwitchState(_workingState);
        }
        private void Update()
        {
            _currentState.Update();
        }
        private void produce()
        {
            if (_recipe == null || !CanCraft())
                return;

            if (OutputStoragePad.ItemsContainer.CanAddItem() == false)
                return;

            Item newItem = _itemsFactory.CreateItem(_recipe.OutputItem);

            for (int i = 0; i < _recipe.InputItems.Count; i++)
            {
                Item inputItem = null;
                StoragePad inputPad = InputStoragePads.ElementAt(i);

                if (!inputPad.ItemsContainer.TakeItem(out inputItem, _recipe.InputItems.ElementAt(i)))
                    return;

                inputItem.Disappear();
            }

            if (OutputStoragePad.ItemsContainer.AddItem(newItem) == false)
            {
                newItem.Disappear();
                return;
            }

            newItem.transform.position = _outputPoint.position;
        }
    }
}
