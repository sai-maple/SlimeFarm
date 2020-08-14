using System;
using System.Numerics;
using UniRx;

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
        IObservable<BigInteger> OnChangeAsObservable();
    }

    public class SlimeNumEntity : ISlimeIncreasable, ISlimeDecreasable, ISlimeNum, IDisposable
    {
        private readonly short[] _splitNum = default;
        private readonly ReactiveProperty<BigInteger> _reactiveSplitNum = default;

        public SlimeNumEntity()
        {
            _splitNum = new short[17];
            _reactiveSplitNum = new ReactiveProperty<BigInteger>(1000000022);
        }

        IObservable<BigInteger> ISlimeNum.OnChangeAsObservable()
        {
            return _reactiveSplitNum;
        }

        void ISlimeIncreasable.Increase(BigInteger num)
        {
            _reactiveSplitNum.Value += num;
        }

        bool ISlimeDecreasable.Decrease(BigInteger num)
        {
            if (_reactiveSplitNum.Value < num) return false;

            _reactiveSplitNum.Value -= num;
            return true;
        }


        public void Dispose()
        {
            _reactiveSplitNum?.Dispose();
        }
    }
}