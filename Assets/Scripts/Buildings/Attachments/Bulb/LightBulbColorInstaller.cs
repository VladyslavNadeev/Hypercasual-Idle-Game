using UnityEngine;
using Zenject;

namespace Buildings.Attachment.Bulb.Installers
{
    public class LightBulbColorInstaller : MonoInstaller
    {
        [SerializeField] private LightBulbColorFactory _factory;

        public override void InstallBindings()
        {
            Container.Bind<LightBulbColorFactory>().FromInstance(_factory).AsSingle().NonLazy();
        }
    }
}
