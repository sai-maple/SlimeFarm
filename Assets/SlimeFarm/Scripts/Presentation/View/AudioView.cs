using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Presentation.Presenter;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class AudioView : MonoBehaviour, IAudioOutputPort
    {
        [SerializeField] private AudioSource _audio = default;

        private readonly Dictionary<Sound, AudioClip> _clips = new Dictionary<Sound, AudioClip>();

        async void IAudioOutputPort.Play(Bgm bgm)
        {
            _audio.clip = await Addressables.LoadAssetAsync<AudioClip>(bgm.ToString());
            _audio.Play();
        }

        async void IAudioOutputPort.PlayOneShot(Sound sound)
        {
            if (!_clips.ContainsKey(sound))
            {
                var clip = await Addressables.LoadAssetAsync<AudioClip>(sound.ToString());
                _clips.Add(sound, clip);
            }

            _audio.PlayOneShot(_clips[sound]);
        }
    }
}