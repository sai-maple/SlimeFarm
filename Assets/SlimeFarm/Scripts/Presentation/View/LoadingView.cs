using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using DG.Tweening;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using UnityEngine.UI;
using Zenject;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text = default;
        [SerializeField] private Slider _slider = default;

        private SignalBus _signalBus = default;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private async void Start()
        {
            _slider.DOValue(1, 3).SetEase(Ease.InOutSine)
                .OnComplete(() => _signalBus.Fire(new ScreenSignal(ScreenEnum.Top)));

            var textAnimator = new DOTweenTMPAnimator(_text);
            for (var count = 0; count < 2; count++)
            {
                for (var i = 0; i < textAnimator.textInfo.characterCount; i++)
                {
                    var currCharOffset = textAnimator.GetCharOffset(i);
                    textAnimator.DOOffsetChar(i, currCharOffset + new Vector3(0, 30, 0), 0.7f)
                        .SetEase(Ease.InOutFlash, 2)
                        .SetDelay(i * 0.2f);
                }

                await UniTask.Delay(TimeSpan.FromSeconds(2.5f));
            }
        }
    }
}