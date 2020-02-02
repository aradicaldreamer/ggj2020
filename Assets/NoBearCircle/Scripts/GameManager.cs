using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Game Variables
    private int _score;
    [SerializeField] private int _scoreToWin = 20;
    private int _dangerLevel;
    [SerializeField] private int _playerHealth = 5;

    // Connected GameObjects
    private AudioManager _audioManager;
    private DisasterSpawnManager _disasterSpawnManager;


    // Start is called before the first frame update
    void Start()
    {
        _audioManager = GameObject.Find("Audio_Manager").GetComponent<AudioManager>();
        if (_audioManager == null) Debug.LogError("The Audio Manager attached to the Game Manager is NULL");
        _disasterSpawnManager = GameObject.Find("Disaster_Spawn_Manager").GetComponent<DisasterSpawnManager>();
        if (_disasterSpawnManager == null) Debug.LogError("The Disaster Spawn Manager attached to the Game Manager is NULL");

        _dangerLevel = 1;
        _disasterSpawnManager.StartSpawning();
        _audioManager.changeAudioLevel(_dangerLevel);
        _audioManager.playOpeningVoiceOver();
    }

    // Update is called once per frame
    void Update()
    {
        DebugControls();
    }

    public void UpdateDangerLevel(int dangerLevel)
    {
        _dangerLevel = dangerLevel;
        _audioManager.changeAudioLevel(_dangerLevel);
    }

    public void UpdateScore()
    {
        _score += 1;
        if (_score == _scoreToWin)
        {
            StartCoroutine(WinRoutine());
        }
    }

    public void Damage()
    {
        _playerHealth --;
        if (_playerHealth == 2)
        {
            UpdateDangerLevel(3);
        }
        if (_playerHealth == 0)
        {
            StartCoroutine(GameOverRoutine());
        }
    }

    IEnumerator GameOverRoutine()
    {
        _audioManager.GameOverAudio();
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene("Main");
    }

    IEnumerator WinRoutine()
    {
        _audioManager.GameWinAudio();
        yield return new WaitForSecondsRealtime(5f);

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
