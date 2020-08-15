using SlimeFarm.Scripts.Domains.Entity;

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

        public TimeUseCase(
            IDayTimeUpdatable dayTimeUpdatable,
            IFarmPerformance farmPerformance,
            ISlimeIncreasable slimeIncreasable)
        {
            _dayTimeUpdatable = dayTimeUpdatable;
            _farmPerformance = farmPerformance;
            _slimeIncreasable = slimeIncreasable;
        }

        void ITimeUpdatable.Update()
        {
            _dayTimeUpdatable.Update();
            _slimeIncreasable.Increase(_farmPerformance.SlimePerFrame);
        }
    }
}