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

    public void Enable()
    {
        enabled = true;
        _volumeChangeDuration = 0;
        _targetVolume = _maxVolume;
        _startingVolume = _audio.volume;
    }

    public void Disable()
    {
        enabled = true;
        _targetVolume = _minVolume;
        _startingVolume = _audio.volume;
        _volumeChangeDuration = 0;
    }

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.volume = _minVolume;
        enabled = false;
    }

    private void Update()
    {
        _audio.volume = Mathf.MoveTowards(_startingVolume, _targetVolume, _volumeChangeNormalizedTime);
        _volumeChangeDuration += Time.deltaTime;
        _volumeChangeNormalizedTime = _volumeChangeDuration / _volumeChangeSpeed;
    }
}
