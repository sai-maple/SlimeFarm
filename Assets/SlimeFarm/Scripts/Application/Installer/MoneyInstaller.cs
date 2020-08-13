using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(NumberWithUnitView))]
    public class MoneyInstaller : MonoInstaller<MoneyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MoneyPresenter>()
                .AsSingle();

            Container.BindInterfacesTo<NumberWithUnitView>()
                .FromComponentOnRoot();
        }
    }
}