using System.Numerics;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface INumberOutPutPort
    {
        void Count(BigInteger number);
    }
}