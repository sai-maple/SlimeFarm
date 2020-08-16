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
    public class ShopFarmView : MonoBehaviour, IShopFarmInOutPort
    {
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _description = default;
        [SerializeField] private TextMeshProUGUI _cost = default;

        [SerializeField] private Button _button = default;

        IObservable<Unit> IShopFarmInOutPort.OnBuyAsObservable()
        {
            return _button.OnClickAsObservable().ThrottleFirst(TimeSpan.FromMilliseconds(500));
        }

        void IShopFarmInOutPort.OnUpdateInfo(FarmInfo farmInfo)
        {
            _name.text = $"牧場 Lv{farmInfo.Level}";
            _description.text =
                $"{NumberConverter.ConvertToChineseNumber(farmInfo.ShipSlime)}匹出荷あたり{NumberConverter.ConvertToChineseNumber(farmInfo.ShipMoney)}円";
            _cost.text = $"{NumberConverter.ConvertToChineseNumber(farmInfo.LevelUpCost)}円";

            if (farmInfo.Level != 11) return;
            _name.text = "牧場 Lv10";
            _button.gameObject.SetActive(false);
        }
    }
}