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

        private readonly Dictionary<string, AudioClip> _clips = new Dictionary<string, AudioClip>();

        async void IAudioInputPort.Play(Bgm bgm)
        {
            _bgmAudio.clip = await Addressables.LoadAssetAsync<AudioClip>(bgm.ToString());
            _bgmAudio.Play();
        }

        async void IAudioInputPort.PlayOneShot(Sound sound)
        {
            // if (sound == Sound.Spawn && _seAudio.isPlaying) return;
            // var assetName = sound != Sound.Spawn ? sound.ToString() : $"{sound}_{Random.Range(0, 7)}";
            //
            // if (!_clips.ContainsKey(assetName))
            // {
            //     var clip = await Addressables.LoadAssetAsync<AudioClip>(assetName);
            //     _clips.Add(assetName, clip);
            // }
            //
            // _seAudio.PlayOneShot(_clips[assetName]);
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