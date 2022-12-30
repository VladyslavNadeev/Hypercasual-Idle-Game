using System;
using UnityEngine;
using Zenject;

namespace Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerControls _playerControls;

        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            Container.Bind<PlayerControls>().FromInstance(_playerControls).AsSingle().NonLazy();
        }
    }
}
