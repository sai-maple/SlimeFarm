using System.Numerics;
using SlimeFarm.Scripts.Application.Utility;
using SlimeFarm.Scripts.Presentation.Presenter;
using TMPro;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class ResultView : MonoBehaviour, IResultOutPutPort
    {
        [SerializeField] private TextMeshProUGUI _slimeNum = default;
        [SerializeField] private TextMeshProUGUI _money = default;
        [SerializeField] private TextMeshProUGUI _day = default;

        void IResultOutPutPort.Initialize(BigInteger slimeNum, BigInteger money, int day)
        {
            _slimeNum.text = $"最終スライム数\n{NumberConverter.ConvertToChineseNumber(slimeNum)}匹";
            _money.text = $"最終所持金\n{NumberConverter.ConvertToChineseNumber(money)}円";
            _day.text = $"かかった日数\n{day}日";
        }
    }
}