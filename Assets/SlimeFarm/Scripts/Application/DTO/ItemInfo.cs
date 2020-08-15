using System;
using System.Numerics;
using UnityEngine;

namespace SlimeFarm.Scripts.Application.DTO
{
    [Serializable]
    public class ItemInfo
    {
        [SerializeField] private short itemId = default;
        [SerializeField] private short level = default;
        [SerializeField] private BigInteger performance = default;
        [SerializeField] private BigInteger cost = default;

        public short ItemId => itemId;
        public short Level => level;
        public BigInteger Performance => performance;
        public BigInteger Cost => cost;
    }
}