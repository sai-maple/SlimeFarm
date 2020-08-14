using System;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class ShipTrackView : MonoBehaviour, IPoolable<IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool = default;

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            transform.localPosition = Vector3.zero;
            var sequence = DOTween.Sequence();
            sequence
                .Append(transform.DOLocalMoveX(5, 0.7f).SetEase(Ease.InOutCubic))
                .AppendInterval(0.3f)
                .Append(transform.DOLocalMoveX(10, 0.7f).SetEase(Ease.InOutCubic))
                .OnComplete(Dispose);
            sequence.Play();
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public void Dispose()
        {
            _pool?.Despawn(this);
        }
    }
}