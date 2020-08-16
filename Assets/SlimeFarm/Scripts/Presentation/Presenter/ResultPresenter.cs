using System.Numerics;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface IResultOutPutPort
    {
        void Initialize(BigInteger slimeNum, BigInteger money, int day);
    }

    public class ResultPresenter
    {
        private readonly IResultOutPutPort _resultOutPutPort = default;
        private readonly ISlimeNum _slimeNum = default;
        private readonly IMoney _money = default;
        private readonly IDay _day = default;

        public ResultPresenter(
            IResultOutPutPort resultOutPutPort,
            ISlimeNum slimeNum,
            IMoney money,
            IDay day)
        {
            _resultOutPutPort = resultOutPutPort;
            _slimeNum = slimeNum;
            _money = money;
            _day = day;
        }

        public void Finish(FinishSignal signal)
        {
            _resultOutPutPort.Initialize(_slimeNum.Num, _money.Num, _day.OnChangeAsObservable().Value);
        }
    }
}