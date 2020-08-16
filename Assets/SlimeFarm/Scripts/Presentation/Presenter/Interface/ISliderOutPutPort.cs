using System;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public interface ISliderOutPutPort
    {
        IObservable<float> OnValueChangedAsObservable();
    }
}