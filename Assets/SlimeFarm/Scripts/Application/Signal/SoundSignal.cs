using SlimeFarm.Scripts.Application.Enum;

namespace SlimeFarm.Scripts.Application.Signal
{
    public class SoundSignal
    {
        public Sound Sound { get; }

        public SoundSignal(Sound sound)
        {
            Sound = sound;
        }
    }
}