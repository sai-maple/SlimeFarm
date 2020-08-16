using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ScreenView : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvas = default;
        [SerializeField] private Animator _animator = default;
        private AnimationStateBehaviour _stateMachine = default;

        private readonly int[] _properties =
        {
            Animator.StringToHash("open"),
            Animator.StringToHash("close"),
            Animator.StringToHash("backIn"),
            Animator.StringToHash("moveOut")
        };

        public void Initialize()
        {
            gameObject.SetActive(false);
        }

        private void Awake()
        {
            _stateMachine = _animator.GetBehaviour<AnimationStateBehaviour>();
            _animator.keepAnimatorControllerStateOnDisable = true;
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _canvas.blocksRaycasts = true;
            _animator.SetTrigger(_properties[0]);
        }

        public void BackIn()
        {
            gameObject.SetActive(true);
            _canvas.blocksRaycasts = true;
            _animator.SetTrigger(_properties[2]);
        }

        public async UniTask MoveOut()
        {
            _canvas.blocksRaycasts = false;
            _animator.SetTrigger(_properties[3]);
            await _stateMachine.OnAnimationStateChanged();
            gameObject.SetActive(false);
        }

        public async UniTask Close()
        {
            _canvas.blocksRaycasts = false;
            _animator.SetTrigger(_properties[1]);

            await _stateMachine.OnAnimationStateChanged();

            gameObject.SetActive(false);
        }

        public void OnDestroy()
        {
            _stateMachine.Dispose();
        }
    }
}