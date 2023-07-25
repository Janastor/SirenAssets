using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSirenControls : MonoBehaviour
{
    [SerializeField] private float _volumeChangeSpeed;
    private AudioSource _audio;
    private float _startingVolume;
    private float _targetVolume;
    private float _minVolume = 0;
    private float _maxVolume = 0.5f;
    private float _volume;
    private float _volumeChangeDuration;
    private float _volumeChangeNormalizedTime;
    private Coroutine ChangeVolumeCoroutine;

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
    
    private void StopVolumeChangeCoroutine()
    {
        if (ChangeVolumeCoroutine != null)
        {
            StopCoroutine(ChangeVolumeCoroutine);
            ChangeVolumeCoroutine = null;
        }
    }
    
    private void StartVolumeChangeCoroutine(float startingVolume, float targetVolume)
    {
        StopVolumeChangeCoroutine();
        ChangeVolumeCoroutine = StartCoroutine(ChangeVolumeOverTime(startingVolume, targetVolume));
    }

    private IEnumerator ChangeVolumeOverTime(float startingVolume, float targetVolume)
    {
        Debug.Log("CoroutineStarted");
        
        float volumeChangeNormalizedTime = 0;
        float volumeChangeDuration = 0;
        
        while (_audio.volume != targetVolume)
        {
            Debug.Log($"VOL: {_audio.volume} | _VolChangeDuration: {volumeChangeDuration} | S/T {startingVolume} / {targetVolume} | Norm: {volumeChangeNormalizedTime}");
            
            _audio.volume = Mathf.MoveTowards(startingVolume, targetVolume, volumeChangeNormalizedTime);
            volumeChangeDuration += Time.deltaTime;
            volumeChangeNormalizedTime = volumeChangeDuration / _volumeChangeSpeed;
            
            yield return null;
        }
    }
    
    
}
