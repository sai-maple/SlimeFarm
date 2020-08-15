using SlimeFarm.Scripts.Domains.Entity;

namespace SlimeFarm.Scripts.Domains.UseCase
{
    public interface IClickSlimeUseCase
    {
        void Click();
    }

    public class ClickSlimeUseCase : IClickSlimeUseCase
    {
        private readonly ISlimeIncreasable _slimeIncreasable = default;
        private readonly IIndexIncrementAble _indexIncrement = default;

        public ClickSlimeUseCase(
            ISlimeIncreasable slimeIncreasable,
            IIndexIncrementAble indexIncrement)
        {
            _slimeIncreasable = slimeIncreasable;
            _indexIncrement = indexIncrement;
        }

        void IClickSlimeUseCase.Click()
        {
            // フィーバーとかあるかも
            _slimeIncreasable.Increase(1);
            _indexIncrement.Increment();
        }
    }
}