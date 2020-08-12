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
        void Decrease(BigInteger num);
    }

    public interface ISlimeNumChangeAsObservable
    {
        IObservable<short[]> SlimeNumAsObservable();
    }

    public class SlimeNumEntity : ISlimeIncreasable, ISlimeDecreasable, ISlimeNumChangeAsObservable, IDisposable
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
            _reactiveSplitNum = new ReactiveProperty<short[]>(new short[17]);
        }

        IObservable<short[]> ISlimeNumChangeAsObservable.SlimeNumAsObservable()
        {
            return _reactiveSplitNum;
        }

        void ISlimeIncreasable.Increase(BigInteger num)
        {
            _slimeNum += num;
            SplitNumber();
        }

        void ISlimeDecreasable.Decrease(BigInteger num)
        {
            _slimeNum -= num;
            SplitNumber();
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