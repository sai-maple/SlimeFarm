using System;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IDayOutputPort
    {
        void Increment(int day);
    }

    public class DayPresenter : IInitializable, IDisposable
    {
        private readonly IDayOutputPort _dayOutputPort = default;
        private readonly IDay _day = default;
        private readonly SignalBus _signalBus = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public DayPresenter(
            IDayOutputPort dayOutputPort,
            IDay day,
            SignalBus signalBus)
        {
            _dayOutputPort = dayOutputPort;
            _day = day;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            Bind();
        }

        private void Bind()
        {
            _day.OnChangeAsObservable()
                .Subscribe(day =>
                {
                    _dayOutputPort.Increment(day);
                    _signalBus.Fire(new SoundSignal(Sound.Day));
                })
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}