using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface ILevelUpFarmUseCase
    {
        bool LevelUp();
    }

    public class LevelUpFarmUseCase : ILevelUpFarmUseCase
    {
        private readonly IMoneyDecreasable _moneyDecreasable = default;
        private readonly IFarmLevelUpdatable _farmLevelUpdatable = default;

        // todo 牧場レベルアップのrepository

        public LevelUpFarmUseCase(
            IMoneyDecreasable moneyDecreasable,
            IFarmLevelUpdatable farmLevelUpdatable)
        {
            _moneyDecreasable = moneyDecreasable;
            _farmLevelUpdatable = farmLevelUpdatable;
        }

        public bool LevelUp()
        {
            if (_moneyDecreasable.Decrease(100)) return false;
            _farmLevelUpdatable.LevelUp();
            return true;
        }
    }
}