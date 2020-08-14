using Cysharp.Threading.Tasks;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Factory;
using SlimeFarm.Scripts.Application.Signal;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class TrackPresenter
    {
        private readonly TrackFactory _trackFactory = default;
        private readonly SignalBus _signalBus = default;

        public TrackPresenter(
            TrackFactory trackFactory,
            SignalBus signalBus)
        {
            _trackFactory = trackFactory;
            _signalBus = signalBus;
        }

        public async void Ship(ShipSignal signal)
        {
            _trackFactory.Create();
            await UniTask.DelayFrame(30);
            _signalBus.Fire(new SoundSignal(Sound.Ship));
        }
    }
}