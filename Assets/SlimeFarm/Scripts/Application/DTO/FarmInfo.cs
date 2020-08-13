using System;
using System.Numerics;
using UnityEngine;

namespace SlimeFarm.Scripts.Application.DTO
{
    [Serializable]
    public class FarmInfo
    {
        [SerializeField] private short _level = default;
        [SerializeField] private BigInteger _levelUpCost = default;
        [SerializeField] private BigInteger _shipMoney = default;
        [SerializeField] private BigInteger _shipSlime = default;

        public short Level => _level;
        public BigInteger LevelUpCost => _levelUpCost;
        public BigInteger ShipMoney => _shipMoney;
        public BigInteger ShipSlime => _shipSlime;

        public FarmInfo(short level, short levelUpCost, short shipMoney, short shipSlime)
        {
            _level = level;
            _levelUpCost = levelUpCost;
            _shipMoney = shipMoney;
            _shipSlime = shipSlime;
        }
    }
}