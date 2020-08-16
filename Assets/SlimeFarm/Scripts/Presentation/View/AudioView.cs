using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SlimeFarm.Scripts.Application.Enum;
using SlimeFarm.Scripts.Presentation.Presenter;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SlimeFarm.Scripts.Presentation.View
{
    public class AudioView : MonoBehaviour, IAudioInputPort
    {
        [SerializeField] private AudioSource _bgmAudio = default;
        [SerializeField] private AudioSource _seAudio = default;

        private readonly Dictionary<Sound, AudioClip> _clips = new Dictionary<Sound, AudioClip>();

        async void IAudioInputPort.Play(Bgm bgm)
        {
            _bgmAudio.clip = await Addressables.LoadAssetAsync<AudioClip>(bgm.ToString());
            _bgmAudio.Play();
        }

        async void IAudioInputPort.PlayOneShot(Sound sound)
        {
            // if (!_clips.ContainsKey(sound))
            // {
            //     var clip = await Addressables.LoadAssetAsync<AudioClip>(sound.ToString());
            //     _clips.Add(sound, clip);
            // }
            //
            // _seAudio.PlayOneShot(_clips[sound]);
        }

        public void SetBgmVolume(float volume)
        {
            _bgmAudio.volume = volume;
        }

        public void SetSeVolume(float volume)
        {
            _seAudio.volume = volume;
        }
    }
}