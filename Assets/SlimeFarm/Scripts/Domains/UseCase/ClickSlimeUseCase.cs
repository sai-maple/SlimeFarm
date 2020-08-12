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

        public ClickSlimeUseCase(
            ISlimeIncreasable slimeIncreasable)
        {
            _slimeIncreasable = slimeIncreasable;
        }

        void IClickSlimeUseCase.Click()
        {
            // フィーバーとかあるかも
            _slimeIncreasable.Increase(1);
        }
    }
}