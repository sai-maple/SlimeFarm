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
            var jsonString = Resources.Load<TextAsset>("").ToString();
            _farmInfos = JsonUtility.FromJson<List<FarmInfo>>(jsonString);
        }

        FarmInfo IFarmRepository.GetNextFarmInfo(FarmInfo currentInfo)
        {
            return _farmInfos[currentInfo.Level];
        }
    }
}