using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterEventFire : MonoBehaviour
{
    // Object Variables
    public int disasterEventID; // 1 fire, 2 flood, 3 volcano
    private Collider _collider;

    // Connected GameObjects
    private AudioManager _audioManager;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _disasterSfx;
    
    // Start is called before the first frame update
    void Start()
    { 
        
        // set which type of disaster
        disasterEventID = 0;
        transform.localPosition = Random.insideUnitSphere;

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

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Water"))
    //     {
             
    //         //_animator.SetTrigger("OnEnemyDeath");
    //         _audioManager.playVoiceOverSuccess(disasterEventID);
            
    //         Destroy(GetComponent<Collider>());
    //         Destroy(this.gameObject, 2.8f);
    //     }
    // }
}
