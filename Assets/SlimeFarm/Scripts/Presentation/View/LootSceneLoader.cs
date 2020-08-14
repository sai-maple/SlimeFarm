using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class LootSceneLoader : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _mask = default;

        private async void Awake()
        {
            var scenes = GetActiveSceneNames();
            if (!scenes.Contains("GameScene"))
            {
                await SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
            }

            if (!scenes.Contains("UIScene"))
            {
                await SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
            }

            _mask.DOFade(0, 1f).SetEase(Ease.InCirc);
        }

        private static List<string> GetActiveSceneNames()
        {
            var sceneCount = SceneManager.sceneCount;
            var activeSceneNames = new List<string>();
            for (var i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                activeSceneNames.Add(scene.name);
            }

            return activeSceneNames;
        }
    }
}