using System;
using System.Numerics;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IMoney
    {
        BigInteger Num { get; }
        IObservable<BigInteger> OnChangeAsObservable();
    }

    public interface IMoneyIncreasable
    {
        void Increase(BigInteger num);
    }

    public interface IMoneyDecreasable
    {
        bool TryDecrease(BigInteger num);
    }

    public class MoneyEntity : IMoney, IMoneyIncreasable, IMoneyDecreasable, IDisposable
    {
        private readonly ReactiveProperty<BigInteger> _money = default;

        public MoneyEntity()
        {
            _money = new ReactiveProperty<BigInteger>();
        }

        BigInteger IMoney.Num => _money.Value;

        IObservable<BigInteger> IMoney.OnChangeAsObservable()
        {
            return _money;
        }

        void IMoneyIncreasable.Increase(BigInteger num)
        {
            _money.Value += num;
        }

        bool IMoneyDecreasable.TryDecrease(BigInteger num)
        {
            if (_money.Value < num) return false;

            _money.Value -= num;
            return true;
        }

        public void Dispose()
        {
            _money?.Dispose();
        }
    }
}