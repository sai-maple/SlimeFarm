using System.Collections.Generic;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface IShopItemListRepository
    {
        IEnumerable<ItemInfo> GetCurrentShopItems(IReadOnlyDictionary<string, short> currentItemLevel);
    }

    public interface IShopItemUseCase
    {
        IEnumerable<ItemInfo> GetShopItemList();
    }

    public class ShopItemUseCase : IShopItemUseCase
    {
        private readonly IShopItemListRepository _shopItemList = default;
        private readonly IItemDictionary _itemDictionary = default;

        public ShopItemUseCase(
            IShopItemListRepository shopItemList,
            IItemDictionary itemDictionary)
        {
            _shopItemList = shopItemList;
            _itemDictionary = itemDictionary;
        }

        IEnumerable<ItemInfo> IShopItemUseCase.GetShopItemList()
        {
            return _shopItemList.GetCurrentShopItems(_itemDictionary.Value);
        }
    }
}