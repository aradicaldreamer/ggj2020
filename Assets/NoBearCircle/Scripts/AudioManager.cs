﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _voiceOver;

    [Header("Background Music")]
    [SerializeField] private AudioClip[] _bgmLevels;
    [SerializeField] private AudioClip[] _win;
    [SerializeField] private AudioClip[] _lose;

    [Header("Voice Over")]
    [SerializeField] private AudioClip _openingVO;
    [SerializeField] private AudioClip[] _voiceOverTaunts;
    [SerializeField] private AudioClip[] _voiceOverSucceeds;
    [SerializeField] private AudioClip[] _voiceOverLoss;

    private bool _stopSpawning = true;
    private bool _isTaunt = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playVoiceOverTaunt(int tauntID)
    {
        if (!_voiceOver.isPlaying)
        {
            _voiceOver.clip = _voiceOverTaunts[tauntID];
            _voiceOver.Play();
        }
    }

    public void playOpeningVoiceOver()
    {
        _voiceOver.PlayOneShot(_openingVO);
    }

    public void playVoiceOverSuccess(int tauntID)
    {
        if (!_voiceOver.isPlaying)
        {
            _voiceOver.clip = _voiceOverSucceeds[tauntID];
            _voiceOver.Play();
        }
    }

    public void GameOverAudio()
    {
        if (!_voiceOver.isPlaying)
        {
            _voiceOver.clip = _voiceOverLoss[Random.Range(0, _voiceOverLoss.Length)];
            _voiceOver.Play();
        }
        _backgroundMusic.Stop();
        _backgroundMusic.clip = _lose[Random.Range(0,1)];
        _backgroundMusic.Play();
    }

    public void GameWinAudio()
    {
        _backgroundMusic.Stop();
        _backgroundMusic.clip = _win[Random.Range(0,1)];
        _backgroundMusic.Play();
    }

    public void changeAudioLevel(int dangerLevel)
    {
        _backgroundMusic.Stop();

        if (dangerLevel == 1)
        {
            _backgroundMusic.clip = _bgmLevels[0];
            _backgroundMusic.loop = true;
            _backgroundMusic.Play();
        }
        if (dangerLevel == 2)
        {
            _backgroundMusic.clip = _bgmLevels[1];
            _backgroundMusic.loop = true;
            _backgroundMusic.Play();
        }
        if (dangerLevel == 3)
        {
            _backgroundMusic.clip = _bgmLevels[2];
            _backgroundMusic.loop = true;
            _backgroundMusic.Play();
        }
    }
}
