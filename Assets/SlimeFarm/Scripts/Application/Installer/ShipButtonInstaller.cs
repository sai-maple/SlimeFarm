using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(ShipButton))]
    public class ShipButtonInstaller : MonoInstaller<ShipButtonInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ShipPresenter>()
                .AsSingle();

            Container.BindInterfacesTo<ShipButton>()
                .FromComponentOnRoot();
        }
    }
}