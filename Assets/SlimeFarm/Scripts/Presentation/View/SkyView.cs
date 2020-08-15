using DG.Tweening;
using SlimeFarm.Scripts.Presentation.Presenter;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class SkyView : MonoBehaviour, ISkyOutputPort
    {
        private Vector3 _rotate = default;

        void ISkyOutputPort.SetRotate(int angle)
        {
            _rotate.z = angle;
            transform.DOLocalRotate(_rotate, 0.5f).SetEase(Ease.Linear);
        }
    }
}