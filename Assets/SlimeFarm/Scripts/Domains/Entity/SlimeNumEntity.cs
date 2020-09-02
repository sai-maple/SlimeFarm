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
        bool TryDecrease(BigInteger num);
    }

    public interface ISlimeNum
    {
        BigInteger Num { get; }
        IObservable<BigInteger> OnChangeAsObservable();
    }

    public class SlimeNumEntity : ISlimeIncreasable, ISlimeDecreasable, ISlimeNum, IDisposable
    {
        private readonly ReactiveProperty<BigInteger> _reactiveSplitNum = default;

        public SlimeNumEntity()
        {
            _reactiveSplitNum = new ReactiveProperty<BigInteger>();
        }

        BigInteger ISlimeNum.Num => _reactiveSplitNum.Value;

        IObservable<BigInteger> ISlimeNum.OnChangeAsObservable()
        {
            return _reactiveSplitNum;
        }

        void ISlimeIncreasable.Increase(BigInteger num)
        {
            _reactiveSplitNum.Value += num;
        }

        bool ISlimeDecreasable.TryDecrease(BigInteger num)
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