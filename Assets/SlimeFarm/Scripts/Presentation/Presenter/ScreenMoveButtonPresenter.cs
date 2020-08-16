using System;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using UniRx;
using UnityEngine.UI;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class ScreenMoveButtonPresenter : IInitializable, IDisposable
    {
        private readonly SignalBus _signalBus = default;
        private readonly Button _button = default;
        private readonly ScreenEnum _screenEnum = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public ScreenMoveButtonPresenter(
            SignalBus signalBus,
            Button button,
            ScreenEnum screenEnum)
        {
            _signalBus = signalBus;
            _button = button;
            _screenEnum = screenEnum;
        }

        public void Initialize()
        {
            SetEvent();
        }

        private void SetEvent()
        {
            _button.OnClickAsObservable()
                .ThrottleFirst(TimeSpan.FromMilliseconds(500))
                .Subscribe(_ =>
                {
                    _signalBus.Fire(new ScreenSignal(_screenEnum));
                    _signalBus.Fire(new SoundSignal(Sound.Apply));
                })
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}