using System.Collections.Generic;
using System.Numerics;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IItem
    {
        void Add(short itemId, BigInteger performance);
        short Num(short itemId);
    }

    public interface IItemDictionary
    {
        IReadOnlyDictionary<short, short> Value { get; }
    }

    public interface IFarmPerformance
    {
        BigInteger SlimePerFrame { get; }
    }

    public class ItemEntity : IItem, IFarmPerformance, IItemDictionary
    {
        private BigInteger _slimePerFrame = default;
        private readonly Dictionary<short, short> _itemNum = default;

        IReadOnlyDictionary<short, short> IItemDictionary.Value => _itemNum;
        BigInteger IFarmPerformance.SlimePerFrame => _slimePerFrame;

        public ItemEntity()
        {
            _slimePerFrame = new BigInteger();
            _itemNum = new Dictionary<short, short>();
            for (short i = 0; i < 10; i++)
            {
                _itemNum.Add(i, 0);
            }
        }

        void IItem.Add(short itemId, BigInteger performance)
        {
            _itemNum[itemId]++;
            _slimePerFrame += performance;
        }

        short IItem.Num(short itemId)
        {
            return _itemNum[itemId];
        }
    }
}