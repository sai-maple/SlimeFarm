using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IAudioOutputPort
    {
        void Play(Bgm bgm);
        void PlayOneShot(Sound sound);
    }

    public class AudioPresenter
    {
        private readonly IAudioOutputPort _audioOutputPort = default;

        public AudioPresenter(IAudioOutputPort audioOutputPort)
        {
            _audioOutputPort = audioOutputPort;
        }

        public void ReceiveBgm(BgmSignal signal)
        {
            _audioOutputPort.Play(signal.Bgm);
        }

        public void ReceiveSound(SoundSignal signal)
        {
            _audioOutputPort.PlayOneShot(signal.Sound);
        }
    }
}