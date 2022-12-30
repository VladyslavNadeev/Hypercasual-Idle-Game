using Items.Container;
using System;
using UnityEngine;
using Zenject;

namespace Items.Factory.Installer
{
    public class ItemsInstaller : MonoInstaller
    {
        [SerializeField] private ItemsFactory _itemsFactory;
        [SerializeField] private ContainerSlotsFactory _containerSlotsFactory;

        public override void InstallBindings()
        {
            Container.Bind<ItemsFactory>().FromInstance(_itemsFactory).AsSingle().NonLazy();
            Container.Bind<ContainerSlotsFactory>().FromInstance(_containerSlotsFactory).AsSingle().NonLazy();
        }
    }
}
