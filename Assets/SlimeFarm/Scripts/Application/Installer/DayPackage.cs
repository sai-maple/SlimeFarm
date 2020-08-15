using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(DayView))]
    public class DayPackage : MonoInstaller<DayPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DayPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<DayView>()
                .FromComponentOnRoot();
        }
    }
}