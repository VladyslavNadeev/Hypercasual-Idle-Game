using Items;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Buildings.ProductionBuilding
{
    [CreateAssetMenu(menuName = "Moon Pioner/Recipe")]
    public class Recipe : ScriptableObject
    {
        public ItemType OutputItem { get => _outputItem; }
        public float ProductionTime { get => _productionTime; }
        public IReadOnlyCollection<ItemType> InputItems { get => _inputItems.ToList().AsReadOnly(); }

        [SerializeField] private ItemType _outputItem;
        [SerializeField, Tooltip("Production time (seconds)")] private float _productionTime;
        [SerializeField] private ItemType[] _inputItems;
    }
}
