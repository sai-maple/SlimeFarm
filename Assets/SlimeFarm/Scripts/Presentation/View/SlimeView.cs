using System;
using AssetStoreTools.FreePixelMob;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SlimeFarm.Scripts.Presentation.Presenter;
using UniRx;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class SlimeView : MonoBehaviour, IPoolable<IMemoryPool>, ISlime
    {
        [SerializeField] private Animator _animator = default;
        private StateRandom _stateMachine = default;
        private IMemoryPool _pool = default;
        private static readonly int Despawn = Animator.StringToHash("DeSpawn");

        private Tweener _tweener = default;

        private readonly Subject<Unit> _subject = new Subject<Unit>();

        IObservable<Unit> ISlime.OnSpawnedAsObservable()
        {
            return _subject.Publish().RefCount();
        }

        private void Start()
        {
            _stateMachine = _animator.GetBehaviour<StateRandom>();
            _animator.keepAnimatorControllerStateOnDisable = true;

            _stateMachine.OnAnimationStateChanged()
                .TakeUntilDestroy(this)
                .Subscribe(_ =>
                {
                    var position = transform.localPosition +
                                   new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
                    position = new Vector3(math.clamp(position.x, -1.7f, 1.7f),
                        math.clamp(position.y, -1.7f, 1.5f));
                    _tweener = transform.DOLocalMove(position, 1.125f);
                });
        }

        public void OnSpawned(IMemoryPool pool)
        {
            _pool = pool;
            transform.localPosition = new Vector3(Random.Range(-1.7f, 1.7f), Random.Range(-1.7f, 1.5f));
            _animator.Play("Spawn");
            _subject.OnNext(Unit.Default);
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public async void Dispose()
        {
            if (!gameObject.activeSelf) return;
            _animator.SetTrigger(Despawn);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            _tweener.Kill();
            _pool?.Despawn(this);
        }

        private void OnDestroy()
        {
            _stateMachine.Dispose();
            _subject.OnCompleted();
            _subject.Dispose();
        }
    }
}