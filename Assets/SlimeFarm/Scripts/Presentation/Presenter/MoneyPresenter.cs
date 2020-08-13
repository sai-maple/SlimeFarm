using System;
using SlimeFarm.Scripts.Domains.Entity;
using UniRx;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class MoneyPresenter : IInitializable, IDisposable
    {
        private readonly INumberOutPutPort _numberOutPutPort = default;
        private readonly IMoney _money = default;

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public MoneyPresenter(
            INumberOutPutPort numberOutPutPort,
            IMoney money)
        {
            _numberOutPutPort = numberOutPutPort;
            _money = money;
        }

        public void Initialize()
        {
            Bind();
        }

        private void Bind()
        {
            _money.OnChangeAsObservable()
                .Subscribe(_numberOutPutPort.Count)
                .AddTo(_disposable);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}