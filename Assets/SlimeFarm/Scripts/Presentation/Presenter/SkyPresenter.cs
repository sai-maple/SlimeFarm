using System;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface ISkyOutputPort
    {
        void SetRotate(int angle);
    }

    public class SkyPresenter : IInitializable, IDisposable
    {
        private readonly ISkyOutputPort _skyOutputPort = default;
        private readonly ISkyAngle _skyAngle = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SkyPresenter(
            ISkyOutputPort skyOutputPort,
            ISkyAngle skyAngle)
        {
            _skyOutputPort = skyOutputPort;
            _skyAngle = skyAngle;
        }

        public void Initialize()
        {
            Bind();
        }

        private void Bind()
        {
            _skyAngle.OnChangeAsObservable()
                .Subscribe(_skyOutputPort.SetRotate)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}