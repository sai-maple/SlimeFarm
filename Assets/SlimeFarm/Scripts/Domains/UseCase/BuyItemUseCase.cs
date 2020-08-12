using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface IBuyItemUseCase
    {
        bool Buy(short itemId);
    }

    public class BuyItemUseCase : IBuyItemUseCase
    {
        private readonly IMoneyDecreasable _moneyDecreasable = default;
        private readonly IItem _item = default;

        // todo アイテムのコストとパフォーマンスのrepository

        public BuyItemUseCase(
            IMoneyDecreasable moneyDecreasable,
            IItem item)
        {
            _moneyDecreasable = moneyDecreasable;
            _item = item;
        }

        bool IBuyItemUseCase.Buy(short itemId)
        {
            if (!_moneyDecreasable.Decrease(100)) return false;
            // todo _item.Num(itemId)を使ってrepositoryからperformanceを持ってくる
            _item.Add(itemId, 100);
            return true;
        }
    }
}