using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _voiceOver;
    [SerializeField] private AudioClip[] _bgmLevels;

    [SerializeField] private AudioClip _openingVO;
    [SerializeField] private AudioClip[] _voiceOverTaunts;
    [SerializeField] private AudioClip[] _voiceOverSucceeds;

    private bool _stopSpawning = true;
    private bool _isTaunt = true;
    
    // Start is called before the first frame update
    void Start()
    {
        changeAudioLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playVoiceOverTaunt(int tauntID)
    {
        _voiceOver.PlayOneShot(_voiceOverTaunts[tauntID]);
    }

    public void playOpeningVoiceOver()
    {
        _voiceOver.PlayOneShot(_openingVO);
    }

    public void playVoiceOverSuccess(int tauntID)
    {
        _voiceOver.PlayOneShot(_voiceOverSucceeds[tauntID]);
    }

    public void StartVO()
    {
        // _stopSpawning = false;
        // StartCoroutine(VoiceOverTest());
    }
    // public IEnumerator VoiceOverTest()
    // {
    //     yield return new WaitForSeconds(15f);
    //     while (!_stopSpawning)
    //     {
    //         int randomTrack = Random.Range(0,6);
    //         if (_isTaunt)
    //         {
    //             playVoiceOverTaunt(randomTrack);
    //             _isTaunt = false;
    //         }
    //         else
    //         {
    //             playVoiceOverSuccess();
    //             _isTaunt = true;
    //         }
    //         yield return new WaitForSeconds(4f);
    //     }
    // }

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
