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
        private readonly IIndexDecrementAble _indexDecrement = default;
        private readonly ISlimeNum _slimeNum = default;

        public ShipUseCaseUseCase(
            IMoneyIncreasable moneyIncreasable,
            ISlimeDecreasable slimeDecreasable,
            IFarmInfo farmInfo,
            IIndexDecrementAble indexDecrement,
            ISlimeNum slimeNum)
        {
            _moneyIncreasable = moneyIncreasable;
            _slimeDecreasable = slimeDecreasable;
            _farmInfo = farmInfo;
            _indexDecrement = indexDecrement;
            _slimeNum = slimeNum;
        }

        bool IShipUseCase.ShipSlime()
        {
            if (!_slimeDecreasable.Decrease(_farmInfo.CurrentInfo.ShipSlime)) return false;
            _moneyIncreasable.Increase(_farmInfo.CurrentInfo.ShipMoney);
            _indexDecrement.Decrement(_slimeNum.Num);
            return true;
        }
    }
}