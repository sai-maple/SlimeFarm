using SlimeFarm.Scripts.Domains.Entity;
using SlimeFarm.Scripts.Domains.UseCase;
using SlimeFarm.Scripts.Presentation.Presenter;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class TimeInstaller : Installer<TimeInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DayTimeEntity>()
                .AsSingle();

            Container.BindInterfacesTo<TimeUseCase>()
                .AsSingle();

            Container.BindInterfacesTo<TimePresenter>()
                .AsSingle().NonLazy();
        }
    }
}