using System;
using SlimeFarm.Scripts.Presentation.Presenter;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class TapArea : MonoBehaviour, ITapAreaInPutPort, IPointerDownHandler
    {
        private readonly Subject<Unit> _subject = new Subject<Unit>();

        IObservable<Unit> ITapAreaInPutPort.OnClickAsObservable()
        {
            return _subject.Publish().RefCount();
        }

        private void OnDestroy()
        {
            _subject.Dispose();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _subject.OnNext(Unit.Default);
        }
    }
}