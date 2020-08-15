using System.Collections.Generic;
using System.Numerics;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IItem
    {
        void Add(string itemId, BigInteger performance);
        short Num(string itemId);
    }

    public interface IItemDictionary
    {
        IReadOnlyDictionary<string, short> Value { get; }
    }

    public interface IFarmPerformance
    {
        BigInteger SlimePerFrame { get; }
    }

    public class ItemEntity : IItem, IFarmPerformance, IItemDictionary
    {
        private BigInteger _slimePerFrame = default;
        private readonly Dictionary<string, short> _itemNum = default;

        IReadOnlyDictionary<string, short> IItemDictionary.Value => _itemNum;
        BigInteger IFarmPerformance.SlimePerFrame => _slimePerFrame;

        public ItemEntity()
        {
            _slimePerFrame = new BigInteger();
            _itemNum = new Dictionary<string, short>();
            for (short i = 0; i < 9; i++)
            {
                _itemNum.Add(i.ToString(), 0);
            }
        }

        void IItem.Add(string itemId, BigInteger performance)
        {
            _itemNum[itemId]++;
            _slimePerFrame += performance;
        }

        short IItem.Num(string itemId)
        {
            return _itemNum[itemId];
        }
    }
}