using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.Presenter;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class AudioPackage : MonoInstaller<AudioPackage>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SoundSignal>();
            Container.DeclareSignal<BgmSignal>();

            Container.BindInterfacesTo<AudioPresenter>()
                .AsSingle().NonLazy();

            Container.BindSignal<SoundSignal>()
                .ToMethod<IAudioSignalReceiver>(x => x.ReceiveSound).FromResolve();
            Container.BindSignal<BgmSignal>()
                .ToMethod<IAudioSignalReceiver>(x => x.ReceiveBgm).FromResolve();
        }
    }
}