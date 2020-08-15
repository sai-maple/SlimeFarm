using System.Collections.Generic;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Domains.UseCase;
using UnityEngine;

namespace SlimeFarm.Scripts.Data.Repository
{
    public class FarmLevelRepository : IFarmRepository
    {
        private readonly List<FarmInfo> _farmInfos = default;

        public FarmLevelRepository()
        {
            var json = Resources.Load<TextAsset>("FarmInfo");
            _farmInfos = JsonUtility.FromJson<Data>(json.text).data;
        }

        FarmInfo IFarmRepository.GetNextFarmInfo(FarmInfo currentInfo)
        {
            return _farmInfos[currentInfo.Level];
        }

        public class Data
        {
            public List<FarmInfo> data;
        }
    }
}