using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.Presenter;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class UiDomainInstaller : MonoInstaller<UiDomainInstaller>
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<ShipSignal>();

            Container.DeclareSignal<ScreenSignal>();
            Container.DeclareSignal<ScreenCloseSignal>();
            
            Container.BindSignal<ScreenSignal>()
                .ToMethod<ScreenPresenter>(p => p.MoveScreen)
                .FromResolve();
            Container.BindSignal<ScreenCloseSignal>()
                .ToMethod<ScreenPresenter>(p => p.CloseScreen)
                .FromResolve();

            // todo 出荷するトラックのFactory
        }
    }
}