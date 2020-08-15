using System.Collections.Generic;
using System.Linq;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Domains.UseCase;
using UnityEngine;

namespace SlimeFarm.Scripts.Data.Repository
{
    public class ItemInfoRepository : IItemRepository, IShopItemListRepository
    {
        private readonly Dictionary<string, List<ItemInfo>> _itemInfos = default;

        public ItemInfoRepository()
        {
            var jsonString = Resources.Load<TextAsset>("ShopItem").text;
            var data = JsonUtility.FromJson<Data>(jsonString);
            _itemInfos = new Dictionary<string, List<ItemInfo>>
            {
                {"0", data.item_0},
                {"1", data.item_1},
                {"2", data.item_2},
                {"3", data.item_3},
                {"4", data.item_4},
                {"5", data.item_5},
                {"6", data.item_6},
                {"7", data.item_7},
                {"8", data.item_8}
            };
        }

        IEnumerable<ItemInfo> IShopItemListRepository.GetCurrentShopItems(
            IReadOnlyDictionary<string, short> currentItemLevel)
        {
            return currentItemLevel.Keys.Select(itemId => _itemInfos[itemId][currentItemLevel[itemId]]);
        }

        ItemInfo IItemRepository.GetItemInfo(string itemId, short currentLevel)
        {
            return _itemInfos[itemId][currentLevel];
        }

        public class Data
        {
            public List<ItemInfo> item_0;
            public List<ItemInfo> item_1;
            public List<ItemInfo> item_2;
            public List<ItemInfo> item_3;
            public List<ItemInfo> item_4;
            public List<ItemInfo> item_5;
            public List<ItemInfo> item_6;
            public List<ItemInfo> item_7;
            public List<ItemInfo> item_8;
        }
    }
}