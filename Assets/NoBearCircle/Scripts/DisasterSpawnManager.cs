using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class DisasterSpawnManager : MonoBehaviour
{
    private bool _stopSpawning = true;
    private float _spawnRate = 10.0f;

    [SerializeField] private GameObject[] _disasterPrefabs;
    [SerializeField] private GameObject _disasterContainer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnDisasterRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        while (!_stopSpawning)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-2f,2f), .5f, .5f);
            GameObject newDisaster = Instantiate(_disasterPrefabs[0], spawnLocation, Quaternion.identity);
            newDisaster.transform.parent = _disasterContainer.transform;
            yield return new WaitForSeconds(_spawnRate);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

    public void StartSpawning()
    {
        _stopSpawning = false;
        StartCoroutine(SpawnDisasterRoutine());
    }
}
