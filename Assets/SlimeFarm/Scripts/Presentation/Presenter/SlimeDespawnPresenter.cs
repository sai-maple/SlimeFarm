using System;
using Cysharp.Threading.Tasks;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface ISlime : IDisposable
    {
        IObservable<Unit> OnSpawnedAsObservable();
    }

    public class SlimeDespawnPresenter : IInitializable, IDisposable
    {
        private readonly ISlime _slime = default;
        private readonly ISlimeNum _slimeNum = default;

        private int _index = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SlimeDespawnPresenter(
            ISlime slime,
            ISlimeNum slimeNum)
        {
            _slime = slime;
            _slimeNum = slimeNum;
        }

        public void Initialize()
        {
            Bind();
            SetEvent();
        }

        private void Bind()
        {
            _slimeNum.OnChangeAsObservable()
                .Where(num => num < _index)
                .Subscribe(_ => _slime.Dispose())
                .AddTo(_disposable);
        }

        private void SetEvent()
        {
            _slime.OnSpawnedAsObservable()
                .Subscribe(_ =>
                {
                    _index = _slimeNum.Num > 50 ? 50 : (int) _slimeNum.Num;
                    if (_index != 50) return;
                    Despawn();
                })
                .AddTo(_disposable);
        }

        private async void Despawn()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            _slime.Dispose();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}