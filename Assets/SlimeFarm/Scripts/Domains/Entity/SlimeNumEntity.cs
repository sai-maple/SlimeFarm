using System;
using System.Numerics;
using UniRx;
using Unity.Mathematics;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface ISlimeIncreasable
    {
        void Increase(BigInteger num);
    }

    public interface ISlimeDecreasable
    {
        bool Decrease(BigInteger num);
    }

    public interface ISlimeNum
    {
        IObservable<short[]> OnChangeAsObservable();
    }

    public class SlimeNumEntity : ISlimeIncreasable, ISlimeDecreasable, ISlimeNum, IDisposable
    {
        private BigInteger _slimeNum = default;
        private readonly short[] _splitNum = default;
        private readonly ReactiveProperty<short[]> _reactiveSplitNum = default;

        private static readonly string[] Units =
        {
            "万", "億", "兆", "京", "垓", "秭", "穣", "溝", "澗", "正",
            "載", "極 ", "恒河沙", "阿僧祇", "那由他", "不可思議", "無量大数"
        };

        public SlimeNumEntity()
        {
            _slimeNum = new BigInteger();
            _splitNum = new short[17];
            _reactiveSplitNum = new ReactiveProperty<short[]>(new short[17]);
        }

        IObservable<short[]> ISlimeNum.OnChangeAsObservable()
        {
            return _reactiveSplitNum;
        }

        void ISlimeIncreasable.Increase(BigInteger num)
        {
            _slimeNum += num;
            SplitNumber();
        }

        bool ISlimeDecreasable.Decrease(BigInteger num)
        {
            if (_slimeNum < num) return false;

            _slimeNum -= num;
            SplitNumber();
            return true;
        }

        private void SplitNumber()
        {
            var num = _slimeNum;
            var splitUnit = (BigInteger) math.pow(10, 4);
            var digit = 0;

            for (; num > 0; num /= splitUnit)
            {
                var x = num % splitUnit;
                _splitNum[digit] = (short) x;
                digit++;
            }

            _reactiveSplitNum.Value = _splitNum;
        }

        public void Dispose()
        {
            _reactiveSplitNum?.Dispose();
        }
    }
}