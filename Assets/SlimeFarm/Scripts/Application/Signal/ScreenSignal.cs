using SlimeFarm.Scripts.Application.Enum;

namespace SlimeFarm.Scripts.Application.Signal
{
    public class ScreenSignal
    {
        public int Screen { get; }

        public ScreenSignal(ScreenEnum screenEnum)
        {
            Screen = (int) screenEnum;
        }
    }
    
    public class ScreenCloseSignal{}
}