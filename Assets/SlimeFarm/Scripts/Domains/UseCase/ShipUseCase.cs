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

        // todo 出荷データのrepository

        public ShipUseCaseUseCase(
            IMoneyIncreasable moneyIncreasable,
            ISlimeDecreasable slimeDecreasable)
        {
            _moneyIncreasable = moneyIncreasable;
            _slimeDecreasable = slimeDecreasable;
        }

        bool IShipUseCase.ShipSlime()
        {
            if (!_slimeDecreasable.Decrease(100)) return false;
            _moneyIncreasable.Increase(100);
            return true;
        }
    }
}