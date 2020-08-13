using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface IShipUseCase
    {
        bool ShipSlime();
    }

    public class ShipUseCaseUseCase : IShipUseCase
    {
        private readonly IMoneyIncreasable _moneyIncreasable = default;
        private readonly ISlimeDecreasable _slimeDecreasable = default;
        private readonly IFarmInfo _farmInfo = default;

        public ShipUseCaseUseCase(
            IMoneyIncreasable moneyIncreasable,
            ISlimeDecreasable slimeDecreasable,
            IFarmInfo farmInfo)
        {
            _moneyIncreasable = moneyIncreasable;
            _slimeDecreasable = slimeDecreasable;
            _farmInfo = farmInfo;
        }

        bool IShipUseCase.ShipSlime()
        {
            if (!_slimeDecreasable.Decrease(_farmInfo.CurrentInfo.ShipSlime)) return false;
            _moneyIncreasable.Increase(_farmInfo.CurrentInfo.ShipMoney);
            return true;
        }
    }
}