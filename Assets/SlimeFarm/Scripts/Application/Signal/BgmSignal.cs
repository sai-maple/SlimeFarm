using SlimeFarm.Scripts.Application.Enum;

namespace SlimeFarm.Scripts.Application.Signal
{
    public class BgmSignal
    {
        public Bgm Bgm { get; }

        public BgmSignal(Bgm bgm)
        {
            Bgm = bgm;
        }
    }
}