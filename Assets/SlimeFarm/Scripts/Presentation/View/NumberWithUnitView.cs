using System.Numerics;
using SlimeFarm.Scripts.Application.Utility;
using SlimeFarm.Scripts.Presentation.Presenter;
using TMPro;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class NumberWithUnitView : MonoBehaviour, INumberOutPutPort
    {
        [SerializeField] private TextMeshProUGUI _text = default;
        [SerializeField] private string _unit = default;

        void INumberOutPutPort.Count(BigInteger number)
        {
            _text.text = $"{NumberConverter.ConvertToChineseNumber(number, 2)}{_unit}";
        }
    }
}