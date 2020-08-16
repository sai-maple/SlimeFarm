using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(ResultView))]
    public class ResultViewPackage : MonoInstaller<ResultViewPackage>
    {
        public override void InstallBindings()
        {
            Container.BindSignal<FinishSignal>()
                .ToMethod<ResultPresenter>(x => x.Finish).FromResolve();

            Container.Bind<ResultPresenter>()
                .AsSingle();

            Container.BindInterfacesTo<ResultView>()
                .FromComponentOnRoot();
        }
    }
}