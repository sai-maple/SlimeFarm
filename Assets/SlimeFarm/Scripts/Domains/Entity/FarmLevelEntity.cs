using System;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IFarmLevel
    {
        IReadOnlyReactiveProperty<short> OnChangeAsObservable();
    }
    
    public interface IFarmLevelUpdatable
    {
        short LevelUp();
    }

    public class FarmLevelEntity : IFarmLevelUpdatable, IFarmLevel, IDisposable
    {
        private readonly ReactiveProperty<short> _farmLevel = default;

        public FarmLevelEntity()
        {
            _farmLevel = new ReactiveProperty<short>(1);
        }

        IReadOnlyReactiveProperty<short> IFarmLevel.OnChangeAsObservable()
        {
            return _farmLevel;
        }

        short IFarmLevelUpdatable.LevelUp()
        {
            _farmLevel.Value++;
            return _farmLevel.Value;
        }

        public void Dispose()
        {
            _farmLevel?.Dispose();
        }
    }
}