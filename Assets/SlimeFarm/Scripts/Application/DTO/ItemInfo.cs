using System;
using System.Numerics;
using UnityEngine;

namespace SlimeFarm.Scripts.Application.DTO
{
    [Serializable]
    public class ItemInfo
    {
        [SerializeField] private short item_id = default;
        [SerializeField] private short level = default;
        [SerializeField] public BigInteger performance = default;
        [SerializeField] public BigInteger cost = default;

        public short ItemId => item_id;
        public short Level => level;
        public BigInteger Performance => performance;
        public BigInteger Cost => cost;
    }
}