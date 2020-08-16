using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface ILevelUpFarmUseCase
    {
        bool LevelUp();
        FarmInfo GetFarmInfo();
    }

    public interface IFarmRepository
    {
        FarmInfo GetNextFarmInfo(FarmInfo currentInfo);
    }

    public class LevelUpFarmUseCase : ILevelUpFarmUseCase
    {
        private readonly IMoneyDecreasable _moneyDecreasable = default;
        private readonly IFarmLevelUpdatable _farmLevelUpdatable = default;
        private readonly IFarmRepository _farmRepository = default;
        private readonly IFarmInfo _farmInfo = default;

        public LevelUpFarmUseCase(
            IMoneyDecreasable moneyDecreasable,
            IFarmLevelUpdatable farmLevelUpdatable,
            IFarmRepository farmRepository,
            IFarmInfo farmInfo)
        {
            _moneyDecreasable = moneyDecreasable;
            _farmLevelUpdatable = farmLevelUpdatable;
            _farmRepository = farmRepository;
            _farmInfo = farmInfo;
        }

        bool ILevelUpFarmUseCase.LevelUp()
        {
            if (!_moneyDecreasable.Decrease(_farmInfo.CurrentInfo.LevelUpCost)) return false;
            _farmLevelUpdatable.LevelUp(_farmRepository.GetNextFarmInfo(_farmInfo.CurrentInfo));
            return true;
        }

        FarmInfo ILevelUpFarmUseCase.GetFarmInfo()
        {
            return _farmInfo.CurrentInfo;
        }
    }
}