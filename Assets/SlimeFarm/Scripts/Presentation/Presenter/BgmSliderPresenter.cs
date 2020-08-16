using System;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class BgmSliderPresenter : IInitializable, IDisposable
    {
        private readonly ISliderOutPutPort _sliderOutPutPort = default;
        private readonly IBgmVolumeChanger _bgmVolumeChanger = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public BgmSliderPresenter(
            ISliderOutPutPort sliderOutPutPort,
            IBgmVolumeChanger bgmVolumeChanger)
        {
            _sliderOutPutPort = sliderOutPutPort;
            _bgmVolumeChanger = bgmVolumeChanger;
        }

        public void Initialize()
        {
            SetEvent();
        }

        private void SetEvent()
        {
            _sliderOutPutPort.OnValueChangedAsObservable()
                .Subscribe(_bgmVolumeChanger.Set)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}