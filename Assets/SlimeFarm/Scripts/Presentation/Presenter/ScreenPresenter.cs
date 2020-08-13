using System.Collections.Generic;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class ScreenPresenter : MonoBehaviour
    {
        [SerializeField] private ScreenView[] _screenViews = default;

        private readonly Stack<int> _screenStack = new Stack<int>();

        public async void MoveScreen(ScreenSignal screenSignal)
        {
            if (_screenStack.Count != 0)
            {
                await _screenViews[_screenStack.Peek()].MoveOut();
            }

            _screenViews[screenSignal.Screen].Open();
            _screenStack.Push(screenSignal.Screen);
        }

        public async void CloseScreen(ScreenCloseSignal closeSignal)
        {
            var screen = _screenStack.Pop();
            await _screenViews[screen].Close();
            _screenViews[screen].BackIn();
        }
    }
}