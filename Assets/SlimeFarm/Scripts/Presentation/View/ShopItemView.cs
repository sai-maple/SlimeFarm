using System;
using Cysharp.Threading.Tasks;
using SlimeFarm.Scripts.Application.DTO;
using SlimeFarm.Scripts.Application.Utility;
using SlimeFarm.Scripts.Presentation.Presenter;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class ShopItemView : MonoBehaviour, IShopItemInOutPort
    {
        [SerializeField] private Image _image = default;
        [SerializeField] private TextMeshProUGUI _name = default;
        [SerializeField] private TextMeshProUGUI _performance = default;
        [SerializeField] private TextMeshProUGUI _cost = default;
        [SerializeField] private Button _button = default;

        private ItemInfo _itemInfo = default;

        IObservable<ItemInfo> IShopItemInOutPort.OnBuyAsObservable()
        {
            return _button.OnClickAsObservable().ThrottleFirst(TimeSpan.FromMilliseconds(500)).Select(_ => _itemInfo);
        }

        public async void OnUpdateInfo(ItemInfo itemInfo)
        {
            _itemInfo = itemInfo;
            _image.sprite = await Addressables.LoadAssetAsync<Sprite>($"shop_item_{itemInfo.ItemId}");
            _name.text = $"{itemInfo.Name} Lv{itemInfo.Level}";
            _performance.text = $"+{NumberConverter.ConvertToChineseNumber(itemInfo.Performance / 2)}/秒";
            _cost.text = $"{NumberConverter.ConvertToChineseNumber(itemInfo.Cost)}円";

            if (itemInfo.Level == 10)
            {
                _button.gameObject.SetActive(false);
            }
        }
    }
}