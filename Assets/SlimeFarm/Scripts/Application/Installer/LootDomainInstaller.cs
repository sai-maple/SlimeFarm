using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Data.Repository;
using SlimeFarm.Scripts.Domains.Entity;
using SlimeFarm.Scripts.Domains.UseCase;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class LootDomainInstaller : MonoInstaller<LootDomainInstaller>
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<ShipSignal>();

            TimeInstaller.Install(Container);
            
            Container.BindInterfacesTo<FarmInfoEntity>()
                .AsSingle();
            Container.BindInterfacesTo<ItemEntity>()
                .AsSingle();
            Container.BindInterfacesTo<MoneyEntity>()
                .AsSingle();
            Container.BindInterfacesTo<SlimeNumEntity>()
                .AsSingle();
            Container.BindInterfacesTo<IndexDespawnIndexEntity>()
                .AsSingle();

            Container.BindInterfacesTo<BuyItemUseCase>()
                .AsSingle();
            Container.BindInterfacesTo<LevelUpFarmUseCase>()
                .AsSingle();
            Container.BindInterfacesTo<ShipUseCaseUseCase>()
                .AsSingle();
            Container.BindInterfacesTo<ClickSlimeUseCase>()
                .AsSingle();

            Container.BindInterfacesTo<FarmLevelRepository>()
                .AsSingle();
            Container.BindInterfacesTo<ItemInfoRepository>()
                .AsSingle();
        }
    }
}