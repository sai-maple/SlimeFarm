using System;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IDay
    {
        IReadOnlyReactiveProperty<int> OnChangeAsObservable();
    }

    public interface ISkyAngle
    {
        IReadOnlyReactiveProperty<int> OnChangeAsObservable();
    }

    public interface IDayTimeUpdatable
    {
        void Update();
    }

    public class DayTimeEntity : IDayTimeUpdatable, IDay, ISkyAngle, IDisposable
    {
        private const int FrameTime = 3;

        private readonly ReactiveProperty<int> _day = default;
        private readonly ReactiveProperty<int> _skyAngle = default;

        public DayTimeEntity()
        {
            _day = new ReactiveProperty<int>();
            _skyAngle = new ReactiveProperty<int>();
        }
        
        IReadOnlyReactiveProperty<int> IDay.OnChangeAsObservable()
        {
            return _day;
        }

        IReadOnlyReactiveProperty<int> ISkyAngle.OnChangeAsObservable()
        {
            return _skyAngle;
        }

        void IDayTimeUpdatable.Update()
        {
            _skyAngle.Value += FrameTime;
            if (_skyAngle.Value < 360) return;
            _skyAngle.Value = 0;
            _day.Value++;
        }

        public void Dispose()
        {
            _day?.Dispose();
            _skyAngle?.Dispose();
        }
    }
}