using System;
using UniRx;

namespace SlimeFarm.Scripts.Domains.Entity
{
    public interface IVolume
    {
        IObservable<float> OnBgmChangedAsObservable();
        IObservable<float> OnSeChangedAsObservable();
    }

    public interface IBgmVolumeChanger
    {
        void Set(float volume);
    }

    public interface ISeVolumeChanger
    {
        void Set(float volume);
    }

    public class VolumeEntity : IVolume, IBgmVolumeChanger, ISeVolumeChanger, IDisposable
    {
        private readonly ReactiveProperty<float> _bgmVolume = default;
        private readonly ReactiveProperty<float> _seVolume = default;

        public VolumeEntity()
        {
            _bgmVolume = new ReactiveProperty<float>(1);
            _seVolume = new ReactiveProperty<float>(1);
        }

        IObservable<float> IVolume.OnBgmChangedAsObservable()
        {
            return _bgmVolume;
        }

        IObservable<float> IVolume.OnSeChangedAsObservable()
        {
            return _seVolume;
        }

        void IBgmVolumeChanger.Set(float volume)
        {
            _bgmVolume.Value = volume;
        }

        void ISeVolumeChanger.Set(float volume)
        {
            _seVolume.Value = volume;
        }

        public void Dispose()
        {
            _bgmVolume?.Dispose();
            _seVolume?.Dispose();
        }
    }
}