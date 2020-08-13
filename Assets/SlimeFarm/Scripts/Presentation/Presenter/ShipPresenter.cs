using System;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.Entity;
using SlimeFarm.Scripts.Domains.UseCase;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IShipInOutPutPort
    {
        IObservable<FarmInfo> OnShipAsObservable();
        void SetCurrentFarmInfo(FarmInfo farmInfo);
    }

    public class ShipPresenter : IInitializable, IDisposable
    {
        private readonly IFarmInfo _farmInfo = default;
        private readonly IShipUseCase _shipUseCase = default;
        private readonly IShipInOutPutPort _shipInOutPutPort = default;
        private readonly SignalBus _signalBus = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public ShipPresenter(
            IFarmInfo farmInfo,
            IShipUseCase shipUseCase,
            IShipInOutPutPort shipInOutPutPort,
            SignalBus signalBus)
        {
            _farmInfo = farmInfo;
            _shipUseCase = shipUseCase;
            _shipInOutPutPort = shipInOutPutPort;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            Bind();
            SetEvent();
        }

        private void Bind()
        {
            _farmInfo.OnChangeAsObservable()
                .Subscribe(_shipInOutPutPort.SetCurrentFarmInfo)
                .AddTo(_disposable);
        }

        private void SetEvent()
        {
            _shipInOutPutPort.OnShipAsObservable()
                .Subscribe(farmInfo =>
                {
                    if (!_shipUseCase.ShipSlime()) return;
                    _signalBus.Fire(new SoundSignal(Sound.Ship));
                    _signalBus.Fire(new ShipSignal(farmInfo.ShipMoney));
                }).AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}