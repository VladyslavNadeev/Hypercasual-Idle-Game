using System;
using UnityEngine;

namespace Interactable
{
    public interface IInteractable
    {
        public float InteractionRadius { get; }
        public void Interact(Player.Player player);
        public void Register();
        public void Unregister();
    }
}
