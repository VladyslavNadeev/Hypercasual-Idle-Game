using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items.Factory
{
    public class ItemsFactory : MonoBehaviour
    {
        [SerializeField] private Item[] _itemPatterns;

        public Item CreateItem(ItemType type)
        {
            IEnumerable<Item> items = _itemPatterns.Where(x => x.Type == type);

            if (items.Count() == 0)
            {
                throw new NullReferenceException($"Can't find item of type {type}");
            }
            if (items.Count() > 1)
            {
                Debug.LogWarning($"There are more than 1 item of type {type}");
            }

            return instantiateItem(items.First());
        }
        private Item instantiateItem(Item item)
        {
            Item instance = Instantiate(item);
            instance.transform.position = Vector3.zero;
            return instance;
        }
    }
}
