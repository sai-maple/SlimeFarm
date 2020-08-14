using SlimeFarm.Scripts.Presentation.View;
using Zenject;

namespace SlimeFarm.Scripts.Application.Factory
{
    public class TrackPool : MonoPoolableMemoryPool<IMemoryPool, ShipTrackView>
    {
    }

    public class TrackFactory : PlaceholderFactory<ShipTrackView>
    {
    }
}