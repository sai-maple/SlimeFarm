using System;
using System.Numerics;
using UniRx;
using Unity.Mathematics;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IMoney
    {
        IObservable<short[]> OnChangeAsObservable();
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
        private BigInteger _money = default;
        private readonly short[] _splitMoney = default;
        private readonly ReactiveProperty<short[]> _reactiveSplitMoney = default;

        public MoneyEntity()
        {
            _money = new BigInteger();
            _splitMoney = new short[17];
            _reactiveSplitMoney = new ReactiveProperty<short[]>(new short[17]);
        }

        IObservable<short[]> IMoney.OnChangeAsObservable()
        {
            return _reactiveSplitMoney;
        }

        void IMoneyIncreasable.Increase(BigInteger num)
        {
            _money += num;
            SplitNumber();
        }

        bool IMoneyDecreasable.Decrease(BigInteger num)
        {
            if (_money < num) return false;

            _money -= num;
            SplitNumber();
            return true;
        }

        private void SplitNumber()
        {
            var num = _money;
            var splitUnit = (BigInteger) math.pow(10, 4);
            var digit = 0;

            for (; num > 0; num /= splitUnit)
            {
                var x = num % splitUnit;
                _splitMoney[digit] = (short) x;
                digit++;
            }

            _reactiveSplitMoney.Value = _splitMoney;
        }

        public void Dispose()
        {
            _reactiveSplitMoney?.Dispose();
        }
    }
}