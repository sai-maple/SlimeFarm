using System;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IDay
    {
        IReadOnlyReactiveProperty<int> OnChangeAsObservable();
    }

    public interface ISunAngle
    {
        IReadOnlyReactiveProperty<int> OnChangeAsObservable();
    }

    public interface IDayTimeUpdatable
    {
        void Update();
    }

    public class DayTimeEntity : IDayTimeUpdatable, IDay, ISunAngle, IDisposable
    {
        private const int FrameTime = 12;

        private readonly ReactiveProperty<int> _day = default;
        private readonly ReactiveProperty<int> _sunAngle = default;

        public DayTimeEntity()
        {
            _day = new ReactiveProperty<int>();
            _sunAngle = new ReactiveProperty<int>();
        }

        IReadOnlyReactiveProperty<int> IDay.OnChangeAsObservable()
        {
            return _day;
        }

        IReadOnlyReactiveProperty<int> ISunAngle.OnChangeAsObservable()
        {
            return _sunAngle;
        }

        void IDayTimeUpdatable.Update()
        {
            _sunAngle.Value += FrameTime;
            if (_sunAngle.Value < 360) return;
            _sunAngle.Value = 0;
            _day.Value++;
        }

        public void Dispose()
        {
            _day?.Dispose();
            _sunAngle?.Dispose();
        }
    }
}