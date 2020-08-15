using System;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.UseCase;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IShopFarmInOutPort
    {
        IObservable<Unit> OnBuyAsObservable();
        void OnUpdateInfo(FarmInfo farmInfo);
    }

    public class LevelUpFarmPresenter : IInitializable, IDisposable
    {
        private readonly IShopFarmInOutPort _shopFarmInOutPort = default;
        private readonly ILevelUpFarmUseCase _levelUpFarmUseCase = default;
        private readonly SignalBus _signalBus = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public LevelUpFarmPresenter(
            IShopFarmInOutPort shopFarmInOutPort,
            ILevelUpFarmUseCase levelUpFarmUseCase,
            SignalBus signalBus)
        {
            _shopFarmInOutPort = shopFarmInOutPort;
            _levelUpFarmUseCase = levelUpFarmUseCase;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _shopFarmInOutPort.OnUpdateInfo(_levelUpFarmUseCase.GetFarmInfo());
            SetEvent();
        }

        private void SetEvent()
        {
            _shopFarmInOutPort.OnBuyAsObservable()
                .Subscribe(itemId =>
                {
                    if (!_levelUpFarmUseCase.LevelUp()) return;
                    _signalBus.Fire(new SoundSignal(Sound.Buy));
                    _shopFarmInOutPort.OnUpdateInfo(_levelUpFarmUseCase.GetFarmInfo());
                }).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}