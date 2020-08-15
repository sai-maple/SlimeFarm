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
            _name.text = $"{farmInfo.Name} Lv{farmInfo.Level}";
            _description.text = farmInfo.Description;
            _cost.text = $"{NumberConverter.ConvertToChineseNumber(farmInfo.LevelUpCost)}円";

            if (farmInfo.Level == 10)
            {
                _button.gameObject.SetActive(false);
            }
        }
    }
}