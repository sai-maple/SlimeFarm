using System;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.Entity;
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
        private readonly ISlimeSpawnIndexer _spawnIndexer = default;
        private readonly SlimeFactory _slimeFactory = default;
        private readonly SignalBus _signalBus = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SlimeSpawnPresenter(
            ITapAreaInPutPort tapAreaInPutPort,
            IClickSlimeUseCase clickSlimeUseCase,
            ISlimeSpawnIndexer spawnIndexer,
            SlimeFactory slimeFactory,
            SignalBus signalBus)
        {
            _tapAreaInPutPort = tapAreaInPutPort;
            _clickSlimeUseCase = clickSlimeUseCase;
            _spawnIndexer = spawnIndexer;
            _slimeFactory = slimeFactory;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            Bind();
            SetEvent();
        }

        private void Bind()
        {
            _spawnIndexer.OnChangeAsObservable()
                .Subscribe(index =>
                {
                    _slimeFactory.Create(index);
                    _signalBus.Fire(new SoundSignal(Sound.Spawn));
                }).AddTo(_disposable);
        }

        private void SetEvent()
        {
            _tapAreaInPutPort.OnClickAsObservable()
                .Subscribe(_ => { _clickSlimeUseCase.Click(); })
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}