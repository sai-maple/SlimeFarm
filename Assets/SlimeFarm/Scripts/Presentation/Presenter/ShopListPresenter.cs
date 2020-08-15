using System;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Domains.UseCase;
using UniRx;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class ShopListPresenter : IInitializable, IDisposable
    {
        private readonly IShopItemUseCase _shopItemUseCase = default;
        private readonly ShopItemFactory _shopItemFactory = default;
        private readonly RectTransform _content = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public ShopListPresenter(
            IShopItemUseCase shopItemUseCase,
            ShopItemFactory shopItemFactory,
            RectTransform content)
        {
            _shopItemUseCase = shopItemUseCase;
            _shopItemFactory = shopItemFactory;
            _content = content;
        }

        public void Initialize()
        {
            foreach (var itemInfo in _shopItemUseCase.GetShopItemList())
            {
                var cell = _shopItemFactory.Create();
                cell.OnUpdateInfo(itemInfo);
                cell.transform.SetParent(_content, false);
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}