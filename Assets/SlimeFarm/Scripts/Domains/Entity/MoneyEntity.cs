using System;
using System.Numerics;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IMoney
    {
        IObservable<BigInteger> OnChangeAsObservable();
    }

    public interface IMoneyIncreasable
    {
        void Increase(BigInteger num);
    }

    public interface IMoneyDecreasable
    {
        bool Decrease(BigInteger num);
    }

    public class MoneyEntity : IMoney, IMoneyIncreasable, IMoneyDecreasable, IDisposable
    {
        private readonly short[] _splitMoney = default;
        private readonly ReactiveProperty<BigInteger> _money = default;

        public MoneyEntity()
        {
            _splitMoney = new short[17];
            _money = new ReactiveProperty<BigInteger>();
        }

        IObservable<BigInteger> IMoney.OnChangeAsObservable()
        {
            return _money;
        }

        void IMoneyIncreasable.Increase(BigInteger num)
        {
            _money.Value += num;
        }

        bool IMoneyDecreasable.Decrease(BigInteger num)
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