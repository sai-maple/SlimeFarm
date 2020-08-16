using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(SliderView))]
    public class SeSliderPackage : MonoInstaller<SeSliderPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SeSliderPresenter>()
                .AsSingle();

            Container.BindInterfacesTo<SliderView>()
                .FromComponentOnRoot();
        }
    }
}