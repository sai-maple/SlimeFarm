using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.Presenter;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class UiDomainInstaller : MonoInstaller<UiDomainInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<ScreenSignal>();
            Container.DeclareSignal<FinishSignal>();

            Container.BindSignal<ScreenSignal>()
                .ToMethod<ScreenPresenter>(p => p.MoveScreen)
                .FromResolve();
        }
    }
}