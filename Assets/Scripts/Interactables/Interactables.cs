using System;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Zenject;
using System.Linq;

namespace Interactable
{
    public class Interactables : MonoBehaviour
    {
        public IReadOnlyCollection<IInteractable> All
        {
            get
            {
                return _interactables.AsReadOnly();
            }
        }
        private List<IInteractable> _interactables = new List<IInteractable>();

        public bool Register(IInteractable interactable)
        {
            if (_interactables.Contains(interactable))
            {
                Debug.LogWarning("Interactable object already exists!");
                return false;
            }

            _interactables.Add(interactable);
            return true;
        }
        public bool Unregister(IInteractable interactable)
        {
            if (!_interactables.Contains(interactable))
            {
                Debug.LogWarning("Interactable object doesn't exists");
                return false;
            }

            return _interactables.Remove(interactable);
        }

        public IEnumerable<IInteractable> GetInteractables(Vector3 origin)
        {
            return All.Where(x => Vector3.Distance(origin, (x as MonoBehaviour).transform.position) <= x.InteractionRadius);
        }
        public IEnumerable<T> GetInteractables<T>(Vector3 origin)
        {
            return GetInteractables(origin).OfType<T>();
        }
    }
}
