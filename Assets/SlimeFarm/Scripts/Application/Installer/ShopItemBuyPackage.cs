using SlimeFarm.Scripts.Domains.UseCase;
using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(ShopItemView))]
    public class ShopItemBuyPackage : MonoInstaller<ShopItemBuyPackage>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BuyItemUseCase>()
                .AsSingle();

            Container.BindInterfacesTo<BuyItemPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<ShopItemView>()
                .FromComponentOnRoot();
        }
    }
}