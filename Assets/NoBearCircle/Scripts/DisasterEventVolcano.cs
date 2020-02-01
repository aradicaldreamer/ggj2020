using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterEventVolcano : MonoBehaviour
{
// Object Variables
    [SerializeField] private int _disasterEventID; // 1 fire, 2 flood, 3 volcano

    // Connected GameObjects
    private AudioManager _audioManager;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _disasterSfx;
    
    // Start is called before the first frame update
    void Start()
    { 

        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();
        if (_audioManager == null) Debug.LogError("The Audio Manager attached to the Disaster Event is NULL");
        _audioSource = GetComponent<AudioSource>();
        if (_audioManager == null) Debug.LogError("The Audio Source attached to the Disaster Event is NULL");
        _audioSource.clip = _disasterSfx;
        //_audioSource.Play();
        //_audioManager.playVoiceOverTaunt(disasterEventID);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cork"))
        {            
            // Trigger destroy animation?
            _audioManager.playVoiceOverSuccess(_disasterEventID);
            
            Destroy(GetComponent<Collider>());
            Destroy(this.gameObject);
        }
    }
}
