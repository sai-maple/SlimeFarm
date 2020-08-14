using System;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.UseCase;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface ITapAreaInPutPort
    {
        IObservable<Unit> OnClickAsObservable();
    }

    public class SlimeSpawnPresenter : IInitializable, IDisposable
    {
        private readonly ITapAreaInPutPort _tapAreaInPutPort = default;
        private readonly IClickSlimeUseCase _clickSlimeUseCase = default;
        private readonly SlimeFactory _slimeFactory = default;
        private readonly SignalBus _signalBus = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SlimeSpawnPresenter(
            ITapAreaInPutPort tapAreaInPutPort,
            IClickSlimeUseCase clickSlimeUseCase,
            SlimeFactory slimeFactory,
            SignalBus signalBus)
        {
            _tapAreaInPutPort = tapAreaInPutPort;
            _clickSlimeUseCase = clickSlimeUseCase;
            _slimeFactory = slimeFactory;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            SetEvent();
        }

        private void SetEvent()
        {
            _tapAreaInPutPort.OnClickAsObservable()
                .Subscribe(_ =>
                {
                    _clickSlimeUseCase.Click();
                    _slimeFactory.Create();
                    _signalBus.Fire(new SoundSignal(Sound.Spawn));
                })
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}