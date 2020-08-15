using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(NumberWithUnitView))]
    public class SlimeNumPackage : MonoInstaller<SlimeNumPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SlimeNumPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<NumberWithUnitView>()
                .FromComponentOnRoot();
        }
    }
}