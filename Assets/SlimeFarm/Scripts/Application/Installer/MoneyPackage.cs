using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(NumberWithUnitView))]
    public class MoneyPackage : MonoInstaller<MoneyPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoneyPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<NumberWithUnitView>()
                .FromComponentOnRoot();
        }
    }
}