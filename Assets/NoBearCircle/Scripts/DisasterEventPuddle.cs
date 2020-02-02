using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterEventPuddle : MonoBehaviour
{
   // Object Variables
    [SerializeField] private int _disasterEventID; // 1 fire, 2 flood, 3 volcano

    // Connected GameObjects
    private GameManager _gameManager;
    private AudioManager _audioManager;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _disasterSfx;
    [SerializeField] private AudioClip _disasterFixedSfx;
    
    // Start is called before the first frame update
    void Start()
    { 
        _disasterEventID = Random.Range(3,6);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if (_gameManager == null) Debug.LogError("The Game Manager attached to the Disaster Event is NULL");
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();
        if (_audioManager == null) Debug.LogError("The Audio Manager attached to the Disaster Event is NULL");
        _audioSource = GetComponent<AudioSource>();
        if (_audioManager == null) Debug.LogError("The Audio Source attached to the Disaster Event is NULL");
        _audioSource.clip = _disasterSfx;
        _audioSource.Play();
        _audioManager.playVoiceOverTaunt(_disasterEventID);
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(15f);
        _gameManager.Damage();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Towel"))
        {            
            // Trigger destroy animation?
            _audioSource.PlayOneShot(_disasterFixedSfx);
            _audioManager.playVoiceOverSuccess(_disasterEventID);
            _gameManager.UpdateScore();
            Destroy(GetComponent<Collider>());
            Destroy(this.gameObject, .5f);
        }
    }
}
