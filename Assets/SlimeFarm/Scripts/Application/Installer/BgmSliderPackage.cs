using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(SliderView))]
    public class BgmSliderPackage : MonoInstaller<BgmSliderPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BgmSliderPresenter>()
                .AsSingle();

            Container.BindInterfacesTo<SliderView>()
                .FromComponentOnRoot();
        }
    }
}