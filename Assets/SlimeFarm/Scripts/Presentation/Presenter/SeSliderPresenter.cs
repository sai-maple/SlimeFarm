using System;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class SeSliderPresenter : IInitializable, IDisposable
    {
        private readonly ISliderOutPutPort _sliderOutPutPort = default;
        private readonly ISeVolumeChanger _seVolumeChanger = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SeSliderPresenter(
            ISliderOutPutPort sliderOutPutPort,
            ISeVolumeChanger seVolumeChanger)
        {
            _sliderOutPutPort = sliderOutPutPort;
            _seVolumeChanger = seVolumeChanger;
        }

        public void Initialize()
        {
            SetEvent();
        }

        private void SetEvent()
        {
            _sliderOutPutPort.OnValueChangedAsObservable()
                .Subscribe(_seVolumeChanger.Set)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}