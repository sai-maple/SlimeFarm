using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Data.Repository;
using SlimeFarm.Scripts.Domains.UseCase;
using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class ShopItemListPackage : MonoInstaller<ShopItemListPackage>
    {
        [SerializeField] private ShopItemView _shopItemPrefab = default;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ShopItemUseCase>()
                .AsSingle();

            Container.BindInterfacesTo<ShopListPresenter>()
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<ItemInfoRepository>()
                .AsSingle();

            Container.BindFactory<ShopItemView, ShopItemFactory>()
                .FromComponentInNewPrefab(_shopItemPrefab);
        }
    }
}