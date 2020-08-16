using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Presentation.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(Button))]
    public class ScreenButtonPackage : MonoInstaller<ScreenButtonPackage>
    {
        [SerializeField] private ScreenEnum _screenEnum = default;

        public override void InstallBindings()
        {
            Container.Bind<ScreenEnum>().FromInstance(_screenEnum).AsSingle();

            Container.BindInterfacesTo<ScreenMoveButtonPresenter>()
                .AsSingle();

            Container.Bind<Button>()
                .FromComponentOnRoot();
        }
    }
}