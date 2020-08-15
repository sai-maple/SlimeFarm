using SlimeFarm.Scripts.Presentation.Presenter;
using TMPro;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DayView : MonoBehaviour, IDayOutputPort
    {
        [SerializeField] private TextMeshProUGUI _text = default;

        void IDayOutputPort.Increment(int day)
        {
            _text.text = $"{day}日目";
        }
    }
}