using System;
using UnityEngine;
using Zenject;

namespace Interactable.Installers
{
    public class InteractablesInstaller : MonoInstaller
    {
        [SerializeField] private Interactables _interactables;

        public override void InstallBindings()
        {
            Container.Bind<Interactables>().FromInstance(_interactables).AsSingle().NonLazy();
        }
    }
}
