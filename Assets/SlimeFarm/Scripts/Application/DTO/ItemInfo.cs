using System;
using System.Numerics;
using UnityEngine;

namespace SlimeFarm.Scripts.Application.DTO
{
    [Serializable]
    public class ItemInfo
    {
        [SerializeField] private string _itemId = default;
        [SerializeField] private string _name = default;
        [SerializeField] private short _level = default;
        [SerializeField] private string _performance = default;
        [SerializeField] private string _cost = default;

        public string ItemId => _itemId;
        public string Name => _name;
        public short Level => _level;
        public BigInteger Performance => BigInteger.Parse(_performance);
        public BigInteger Cost => BigInteger.Parse(_cost);
    }
}