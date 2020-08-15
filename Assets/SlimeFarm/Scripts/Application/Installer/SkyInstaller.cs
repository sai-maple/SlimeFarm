using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(SkyView))]
    public class SkyInstaller : MonoInstaller<SkyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SkyPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<SkyView>()
                .FromComponentOnRoot();
        }
    }
}