using System;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface ISlime
    {
        void Despawn(int index);
    }

    public class SlimeDespawnPresenter : IInitializable, IDisposable
    {
        private readonly ISlime _slime = default;
        private readonly ISlimeDespawnIndexer _slimeDespawnIndexer = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SlimeDespawnPresenter(
            ISlime slime,
            ISlimeDespawnIndexer slimeDespawnIndexer)
        {
            _slime = slime;
            _slimeDespawnIndexer = slimeDespawnIndexer;
        }

        public void Initialize()
        {
            Bind();
        }

        private void Bind()
        {
            _slimeDespawnIndexer.OnChangeAsObservable()
                .Subscribe(_slime.Despawn)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}