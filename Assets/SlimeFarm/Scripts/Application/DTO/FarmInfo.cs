using System;
using System.Numerics;
using UnityEngine;

namespace SlimeFarm.Scripts.Application.DTO
{
    [Serializable]
    public class FarmInfo
    {
        [SerializeField] private string _name = default;
        [SerializeField] private short _level = default;
        [SerializeField] private string _description = default;
        [SerializeField] private BigInteger _levelUpCost = default;
        [SerializeField] private BigInteger _shipMoney = default;
        [SerializeField] private BigInteger _shipSlime = default;

        public string Name => _name;
        public short Level => _level;
        public string Description => _description;
        public BigInteger LevelUpCost => _levelUpCost;
        public BigInteger ShipMoney => _shipMoney;
        public BigInteger ShipSlime => _shipSlime;

        public FarmInfo(string name, short level, string description, short levelUpCost, short shipMoney,
            short shipSlime)
        {
            _name = name;
            _level = level;
            _description = description;
            _levelUpCost = levelUpCost;
            _shipMoney = shipMoney;
            _shipSlime = shipSlime;
        }
    }
}