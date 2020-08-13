using System;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Application.Utility;
using SlimeFarm.Scripts.Presentation.Presenter;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class ShipButton : MonoBehaviour, IShipInOutPutPort
    {
        [SerializeField] private Button _button = default;
        [SerializeField] private TextMeshProUGUI _cost = default;

        private FarmInfo _farmInfo = default;

        IObservable<FarmInfo> IShipInOutPutPort.OnShipAsObservable()
        {
            return _button.OnClickAsObservable().Select(_ => _farmInfo);
        }

        void IShipInOutPutPort.SetCurrentFarmInfo(FarmInfo farmInfo)
        {
            _farmInfo = farmInfo;
            _cost.text = $"{NumberConverter.ConvertToChineseNumber(farmInfo.ShipSlime)}匹";
        }
    }
}