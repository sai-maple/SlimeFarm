using System;
using System.Collections.Generic;
using System.Numerics;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface ISlimeDespawnIndexer
    {
        IObservable<int> OnChangeAsObservable();
    }

    public interface ISlimeSpawnIndexer
    {
        IObservable<int> OnChangeAsObservable();
    }

    public interface IIndexIncrementAble
    {
        void Increment();
    }

    public interface IIndexDecrementAble
    {
        void Decrement(BigInteger num);
    }

    public class SpawnIndexEntity : ISlimeDespawnIndexer, ISlimeSpawnIndexer, IIndexIncrementAble,
        IIndexDecrementAble, IDisposable
    {
        private readonly Subject<int> _slimeIndex = default;
        private readonly Subject<int> _spawnIndex = default;
        private readonly Queue<int> _queue = default;

        private const int Limit = 50;
        private int _index = default;

        public SpawnIndexEntity()
        {
            _slimeIndex = new Subject<int>();
            _spawnIndex = new Subject<int>();
            _queue = new Queue<int>();
        }

        IObservable<int> ISlimeDespawnIndexer.OnChangeAsObservable()
        {
            return _slimeIndex;
        }

        IObservable<int> ISlimeSpawnIndexer.OnChangeAsObservable()
        {
            return _spawnIndex;
        }

        void IIndexIncrementAble.Increment()
        {
            if (_queue.Count == Limit) _slimeIndex.OnNext(_queue.Dequeue());
            _index++;
            _index = _index > Limit ? 1 : _index;
            _queue.Enqueue(_index);
            _spawnIndex.OnNext(_index);
        }

        void IIndexDecrementAble.Decrement(BigInteger num)
        {
            if (num > Limit) return;
            while (num < _queue.Count)
            {
                _slimeIndex.OnNext(_queue.Dequeue());
            }
        }

        public void Dispose()
        {
            _slimeIndex?.OnCompleted();
            _slimeIndex?.Dispose();
            _spawnIndex?.OnCompleted();
            _spawnIndex?.Dispose();
        }
    }
}