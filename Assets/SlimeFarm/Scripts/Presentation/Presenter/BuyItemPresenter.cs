using System;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.UseCase;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IShopItemInOutPort
    {
        void OnUpdateInfo(ItemInfo itemInfo);
        IObservable<ItemInfo> OnBuyAsObservable();
    }

    public class BuyItemPresenter : IInitializable, IDisposable
    {
        private readonly IShopItemInOutPort _shopItemInOutPort = default;
        private readonly IBuyItemUseCase _buyItemUseCase = default;
        private readonly SignalBus _signalBus = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public BuyItemPresenter(
            IShopItemInOutPort shopItemInOutPort,
            IBuyItemUseCase buyItemUseCase,
            SignalBus signalBus)
        {
            _shopItemInOutPort = shopItemInOutPort;
            _buyItemUseCase = buyItemUseCase;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            SetEvent();
        }

        private void SetEvent()
        {
            _shopItemInOutPort.OnBuyAsObservable()
                .Subscribe(itemInfo =>
                {
                    if (!_buyItemUseCase.Buy(itemInfo.ItemId)) return;
                    _signalBus.Fire(new SoundSignal(Sound.Buy));
                    _shopItemInOutPort.OnUpdateInfo(_buyItemUseCase.GetItemInfo(itemInfo.ItemId));
                }).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}