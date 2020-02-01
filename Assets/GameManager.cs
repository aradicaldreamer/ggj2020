using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Game Variables

    // Connected GameObjects
    private AudioManager _audioManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();
        if (_audioManager == null) Debug.LogError("The Audio Manager attached to the Game Manager is NULL");
        
        _audioManager.playOpeningVoiceOver();
        _audioManager.StartVO();
    }

    // Update is called once per frame
    void Update()
    {
        DebugControls();
    }


    void DebugControls()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _audioManager.changeAudioLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _audioManager.changeAudioLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _audioManager.changeAudioLevel(3);
        }
        
    }
}
