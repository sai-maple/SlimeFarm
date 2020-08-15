using System;
using SlimeFarm.Scripts.Application.DTO;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IFarmInfo
    {
        FarmInfo CurrentInfo { get; }
        IReadOnlyReactiveProperty<FarmInfo> OnChangeAsObservable();
    }

    public interface IFarmLevelUpdatable
    {
        void LevelUp(FarmInfo next);
    }

    public class FarmInfoEntity : IFarmLevelUpdatable, IFarmInfo, IDisposable
    {
        private readonly ReactiveProperty<FarmInfo> _farmInfo = default;

        FarmInfo IFarmInfo.CurrentInfo => _farmInfo.Value;

        public FarmInfoEntity()
        {
            _farmInfo = new ReactiveProperty<FarmInfo>(new FarmInfo("農場",1,"10匹出荷で100円", 100, 100, 10));
        }

        IReadOnlyReactiveProperty<FarmInfo> IFarmInfo.OnChangeAsObservable()
        {
            return _farmInfo;
        }

        void IFarmLevelUpdatable.LevelUp(FarmInfo next)
        {
            _farmInfo.Value = next;
        }

        public void Dispose()
        {
            _farmInfo?.Dispose();
        }
    }
}