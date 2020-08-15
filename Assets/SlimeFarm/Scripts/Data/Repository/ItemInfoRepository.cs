using System.Collections.Generic;
using System.Linq;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Domains.UseCase;
using UnityEngine;

namespace SlimeFarm.Scripts.Data.Repository
{
    public class ItemInfoRepository : IItemRepository
    {
        private readonly Dictionary<short, List<ItemInfo>> _itemInfos = default;

        public ItemInfoRepository()
        {
            var jsonString = Resources.Load<TextAsset>("").ToString();
            _itemInfos = JsonUtility.FromJson<Dictionary<short, List<ItemInfo>>>(jsonString);
        }

        public IEnumerable<ItemInfo> GetDefaultShopItems()
        {
            return _itemInfos.Values.Select(infos => infos[0]);
        }

        public IEnumerable<ItemInfo> GetCurrentShopItems(IEnumerable<(short, short)> currentItemLevel)
        {
            return currentItemLevel.Select(info => _itemInfos[info.Item1][info.Item2]);
        }

        ItemInfo IItemRepository.GetItemInfo(short itemId, short currentNum)
        {
            return _itemInfos[itemId][currentNum];
        }
    }
}