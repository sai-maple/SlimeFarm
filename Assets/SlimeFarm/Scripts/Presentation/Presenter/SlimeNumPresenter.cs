using System;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class SlimeNumPresenter : IInitializable, IDisposable
    {
        private readonly INumberOutPutPort _numberOutPutPort = default;
        private readonly ISlimeNum _slimeNum = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public SlimeNumPresenter(
            INumberOutPutPort numberOutPutPort,
            ISlimeNum slimeNum)
        {
            _numberOutPutPort = numberOutPutPort;
            _slimeNum = slimeNum;
        }

        public void Initialize()
        {
            Bind();
        }

        private void Bind()
        {
            _slimeNum.OnChangeAsObservable()
                .Subscribe(_numberOutPutPort.Count)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}