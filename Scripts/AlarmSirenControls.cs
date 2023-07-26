using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmSirenControls : MonoBehaviour
{
    
    [SerializeField] private float _volumeChangeSpeed;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    private AudioSource _audio;
    private Coroutine _changeVolumeCoroutine;

    public void Enable()
    {
        StartVolumeChangeCoroutine(_audio.volume, _maxVolume);
    }

    public void Disable()
    {
        StartVolumeChangeCoroutine(_audio.volume, _minVolume);
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _minVolume;
        enabled = false;
    }
    
    private void StartVolumeChangeCoroutine(float startingVolume, float targetVolume)
    {
        if (_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
            _changeVolumeCoroutine = null;
        }
        
        _changeVolumeCoroutine = StartCoroutine(ChangeVolumeOverTime(startingVolume, targetVolume));
    }

    private IEnumerator ChangeVolumeOverTime(float startingVolume, float targetVolume)
    {
        float volumeChangeNormalizedTime = 0;
        float volumeChangeDuration = 0;
        
        if (_audio.isPlaying == false)
            _audio.Play();
        
        while (_audio.volume != targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(startingVolume, targetVolume, volumeChangeNormalizedTime);
            volumeChangeDuration += Time.deltaTime;
            volumeChangeNormalizedTime = volumeChangeDuration / _volumeChangeSpeed;
            
            yield return null;
        }
        
        if (_audio.volume <= _minVolume)
            _audio.Stop();
    }
    
    
}
