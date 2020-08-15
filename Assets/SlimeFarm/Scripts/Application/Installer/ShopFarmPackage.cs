using SlimeFarm.Scripts.Data.Repository;
using SlimeFarm.Scripts.Domains.UseCase;
using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(ShopFarmView))]
    public class ShopFarmPackage : MonoInstaller<ShopFarmPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelUpFarmUseCase>()
                .AsSingle();

            Container.BindInterfacesTo<LevelUpFarmPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<FarmLevelRepository>()
                .AsSingle();

            Container.BindInterfacesTo<ShopFarmView>()
                .FromComponentOnRoot();
        }
    }
}