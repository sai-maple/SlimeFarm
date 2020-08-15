using System;
using SlimeFarm.Scripts.Domains.UseCase;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class TimePresenter : IInitializable, IDisposable
    {
        private readonly ITimeUpdatable _timeUpdatable = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public TimePresenter(ITimeUpdatable timeUpdatable)
        {
            _timeUpdatable = timeUpdatable;
        }

        public void Initialize()
        {
            SetEvent();
        }

        private void SetEvent()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(500))
                .Subscribe(_ => _timeUpdatable.Update())
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}