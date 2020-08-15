using SlimeFarm.Scripts.Presentation.View;
using Zenject;

namespace SlimeFarm.Scripts.Application.Factory
{
    public class SlimePool : MonoPoolableMemoryPool<int, IMemoryPool, SlimeView>
    {
    }

    public class SlimeFactory : PlaceholderFactory<int, SlimeView>
    {
    }
}