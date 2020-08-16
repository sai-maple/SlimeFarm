using SlimeFarm.Scripts.Domains.Entity;
using UnityEngine;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface ITimeUpdatable
    {
        void Update();
    }

    public class TimeUseCase : ITimeUpdatable
    {
        private readonly IDayTimeUpdatable _dayTimeUpdatable = default;
        private readonly IFarmPerformance _farmPerformance = default;
        private readonly ISlimeIncreasable _slimeIncreasable = default;
        private readonly IIndexIncrementAble _indexIncrement = default;

        private float _deltaTime = default;

        public TimeUseCase(
            IDayTimeUpdatable dayTimeUpdatable,
            IFarmPerformance farmPerformance,
            ISlimeIncreasable slimeIncreasable,
            IIndexIncrementAble indexIncrement)
        {
            _dayTimeUpdatable = dayTimeUpdatable;
            _farmPerformance = farmPerformance;
            _slimeIncreasable = slimeIncreasable;
            _indexIncrement = indexIncrement;
        }

        void ITimeUpdatable.Update()
        {
            _dayTimeUpdatable.Update();
            var slime = _farmPerformance.SlimePerFrame;
            _slimeIncreasable.Increase(slime);
            if (slime == 0 || _deltaTime <= 2f)
            {
                _deltaTime += 0.5f;
                return;
            }

            _deltaTime = 0;
            _indexIncrement.Increment();
        }
    }
}