using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.Presenter;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Application.Installer
{
    public class ShipTrackPackage : MonoInstaller<ShipTrackPackage>
    {
        [SerializeField] private ShipTrackView _shipTrackPrefab = default;

        public override void InstallBindings()
        {
            Container.Bind<TrackPresenter>()
                .AsSingle().NonLazy();

            Container.BindSignal<ShipSignal>()
                .ToMethod<TrackPresenter>(p => p.Ship)
                .FromResolve();

            Container.BindFactory<ShipTrackView, TrackFactory>()
                .FromPoolableMemoryPool<ShipTrackView, TrackPool>(poolBinder => poolBinder
                    .WithInitialSize(10)
                    .FromComponentInNewPrefab(_shipTrackPrefab)
                    .UnderTransform(transform));
        }
    }
}