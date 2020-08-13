using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.Presenter;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class AudioInstaller : MonoInstaller<AudioInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<SoundSignal>();
            Container.DeclareSignal<BgmSignal>();

            Container.Bind<AudioPresenter>()
                .AsSingle();

            Container.BindSignal<SoundSignal>()
                .ToMethod<AudioPresenter>(x => x.ReceiveSound).FromResolve();
            Container.BindSignal<BgmSignal>()
                .ToMethod<AudioPresenter>(x => x.ReceiveBgm).FromResolve();
        }
    }
}