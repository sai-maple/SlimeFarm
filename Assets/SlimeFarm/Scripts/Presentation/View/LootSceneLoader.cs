using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class LootSceneLoader : MonoBehaviour
    {
        private async void Awake()
        {
            if (!SceneManager.GetSceneByName("GameScene").isLoaded)
            {
                await SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Additive);
            }

            if (!SceneManager.GetSceneByName("UIScene").isLoaded)
            {
                await SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
            }
        }
    }
}