using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private string _keyVolume;
    [SerializeField] private MusicPlayer _musicPlayer;

    public event Action<float> VolumeChanged;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_keyVolume))
        {
            _slider.value = PlayerPrefs.GetFloat(_keyVolume);
        }
        else
        {
            _slider.value = 1;
        }
    }

    public void ChangeVolume()
    {
        if(_musicPlayer != null)
        {
            _musicPlayer.ChangeVolume(_slider.value);
        }

        VolumeChanged?.Invoke(_slider.value);        
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(_keyVolume, _slider.value);
    }
}
