using System;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IAudioInputPort
    {
        void Play(Bgm bgm);
        void PlayOneShot(Sound sound);

        void SetBgmVolume(float volume);
        void SetSeVolume(float volume);
    }

    public interface IAudioSignalReceiver
    {
        void ReceiveBgm(BgmSignal signal);
        void ReceiveSound(SoundSignal signal);
    }

    public class AudioPresenter : IInitializable, IAudioSignalReceiver, IDisposable
    {
        private readonly IAudioInputPort _audioInputPort = default;
        private readonly IVolume _volume = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public AudioPresenter(
            IAudioInputPort audioInputPort,
            IVolume volume)
        {
            _audioInputPort = audioInputPort;
            _volume = volume;
        }

        public void Initialize()
        {
            Bind();
        }

        private void Bind()
        {
            _volume.OnBgmChangedAsObservable()
                .Subscribe(_audioInputPort.SetBgmVolume)
                .AddTo(_disposable);

            _volume.OnSeChangedAsObservable()
                .Subscribe(_audioInputPort.SetSeVolume)
                .AddTo(_disposable);
        }

        void IAudioSignalReceiver.ReceiveBgm(BgmSignal signal)
        {
            _audioInputPort.Play(signal.Bgm);
        }

        void IAudioSignalReceiver.ReceiveSound(SoundSignal signal)
        {
            _audioInputPort.PlayOneShot(signal.Sound);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}