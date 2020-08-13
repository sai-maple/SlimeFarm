using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class ScreenStateBehaviour : StateMachineBehaviour, IDisposable
    {
        private readonly ReactiveProperty<int> _animationState = new ReactiveProperty<int>();

        public IReadOnlyReactiveProperty<int> OnAnimationStateChanged() => _animationState;

        public override async void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            await UniTask.Delay(TimeSpan.FromSeconds(stateInfo.length));
            _animationState.Value = stateInfo.shortNameHash;
        }

        public void Dispose()
        {
            _animationState?.Dispose();
        }
    }
}