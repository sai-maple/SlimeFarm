using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(SlimeView))]
    public class SlimeDePopInstaller : MonoInstaller<SlimeDePopInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SlimeView>()
                .FromComponentOnRoot();

            Container.BindInterfacesTo<SlimeDespawnPresenter>()
                .AsSingle();
        }
    }
}