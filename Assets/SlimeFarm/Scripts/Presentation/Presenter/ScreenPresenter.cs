using System;
using System.Collections.Generic;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Application.Signal;
using SlimeFarm.Scripts.Presentation.View;
using UnityEngine;

namespace SlimeFarm.Scripts.Presentation.Presenter
{
    public class ScreenPresenter : MonoBehaviour
    {
        [SerializeField] private ScreenView[] _screenViews = default;

        private readonly Stack<int> _screenStack = new Stack<int>();

        private void Awake()
        {
            _screenStack.Push((int) ScreenEnum.Loading);
            for (var i = 1; i < _screenViews.Length; i++)
            {
                _screenViews[i].Initialize();
            }
        }

        public async void MoveScreen(ScreenSignal screenSignal)
        {
            if (screenSignal.Screen == (int) ScreenEnum.Close)
            {
                CloseScreen();
                return;
            }

            if (_screenStack.Count != 0)
            {
                await _screenViews[_screenStack.Peek()].MoveOut();
            }

            _screenViews[screenSignal.Screen].Open();
            _screenStack.Push(screenSignal.Screen);
        }

        private async void CloseScreen()
        {
            var screen = _screenStack.Pop();
            await _screenViews[screen].Close();
            _screenViews[_screenStack.Peek()].BackIn();
        }
    }
}