using System;
using System.Numerics;
using UnityEngine;

namespace SlimeFarm.Scripts.Application.DTO
{
    [Serializable]
    public class FarmInfo
    {
        [SerializeField] private short _level = default;
        [SerializeField] private string _levelUpCost = default;
        [SerializeField] private string _shipMoney = default;
        [SerializeField] private string _shipSlime = default;

        public short Level => _level;
        public BigInteger LevelUpCost => BigInteger.Parse(_levelUpCost);
        public BigInteger ShipMoney => BigInteger.Parse(_shipMoney);
        public BigInteger ShipSlime => BigInteger.Parse(_shipSlime);

        public FarmInfo(short level, string levelUpCost, string shipMoney,
            string shipSlime)
        {
            _level = level;
            _levelUpCost = levelUpCost;
            _shipMoney = shipMoney;
            _shipSlime = shipSlime;
        }
    }
}