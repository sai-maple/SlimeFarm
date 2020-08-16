using System;
using SlimeFarm.Scripts.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class SliderView : MonoBehaviour, ISliderOutPutPort
    {
        [SerializeField] private Slider _slider = default;

        IObservable<float> ISliderOutPutPort.OnValueChangedAsObservable()
        {
            return _slider.onValueChanged.AsObservable();
        }
    }
}