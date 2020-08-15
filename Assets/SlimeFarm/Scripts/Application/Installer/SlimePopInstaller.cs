using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    [RequireComponent(typeof(TapArea))]
    public class SlimePopInstaller : MonoInstaller<SlimePopInstaller>
    {
        [SerializeField] private SlimeView _slimePrefab = default;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SlimeSpawnPresenter>()
                .AsSingle();

            Container.BindInterfacesTo<TapArea>()
                .FromComponentOnRoot();

            Container.BindFactory<int, SlimeView, SlimeFactory>()
                .FromPoolableMemoryPool<int, SlimeView, SlimePool>(poolBinder => poolBinder
                    .WithMaxSize(50)
                    .FromComponentInNewPrefab(_slimePrefab)
                    .UnderTransform(transform));
        }
    }
}