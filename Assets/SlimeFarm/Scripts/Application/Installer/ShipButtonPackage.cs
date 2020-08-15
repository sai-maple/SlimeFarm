using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(ShipButton))]
    public class ShipButtonPackage : MonoInstaller<ShipButtonPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ShipPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<ShipButton>()
                .FromComponentOnRoot();
        }
    }
}