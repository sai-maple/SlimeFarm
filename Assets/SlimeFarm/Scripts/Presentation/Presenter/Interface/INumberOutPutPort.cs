using System.Collections.Generic;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface INumberOutPutPort
    {
        void Count(IEnumerable<short> splitNum);
    }
}