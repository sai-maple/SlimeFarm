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

            Container.BindInterfacesTo<DayTimeEntity>()
                .AsSingle();
            Container.BindInterfacesTo<FarmLevelEntity>()
                .AsSingle();
            Container.BindInterfacesTo<ItemEntity>()
                .AsSingle();
            Container.BindInterfacesTo<MoneyEntity>()
                .AsSingle();
            Container.BindInterfacesTo<SlimeNumEntity>()
                .AsSingle();

            Container.BindInterfacesTo<BuyItemUseCase>()
                .AsSingle();
            Container.BindInterfacesTo<ClickSlimeUseCase>()
                .AsSingle();
            Container.BindInterfacesTo<LevelUpFarmUseCase>()
                .AsSingle();
            Container.BindInterfacesTo<ShipUseCaseUseCase>()
                .AsSingle();
        }
    }
}