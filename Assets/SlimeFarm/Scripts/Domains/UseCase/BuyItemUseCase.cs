using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface IBuyItemUseCase
    {
        bool Buy(string itemId);
        ItemInfo GetItemInfo(string itemId);
    }

    public interface IItemRepository
    {
        ItemInfo GetItemInfo(string itemId, short currentNum);
    }

    public class BuyItemUseCase : IBuyItemUseCase
    {
        private readonly IMoneyDecreasable _moneyDecreasable = default;
        private readonly IItem _item = default;
        private readonly IItemRepository _itemRepository = default;

        public BuyItemUseCase(
            IMoneyDecreasable moneyDecreasable,
            IItem item,
            IItemRepository itemRepository)
        {
            _moneyDecreasable = moneyDecreasable;
            _item = item;
            _itemRepository = itemRepository;
        }

        bool IBuyItemUseCase.Buy(string itemId)
        {
            var itemInfo = _itemRepository.GetItemInfo(itemId, _item.Num(itemId));
            if (!_moneyDecreasable.TryDecrease(itemInfo.Cost)) return false;
            _item.Add(itemId, itemInfo.Performance);
            return true;
        }

        ItemInfo IBuyItemUseCase.GetItemInfo(string itemId)
        {
            return _itemRepository.GetItemInfo(itemId, _item.Num(itemId));
        }
    }
}