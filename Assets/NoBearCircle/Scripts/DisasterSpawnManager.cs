using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class DisasterSpawnManager : MonoBehaviour
{
    private bool _stopSpawning = true;
    private float _spawnRate = 2.0f;

    [SerializeField] private GameObject[] _disasterPrefabs;
    [SerializeField] private GameObject _earth;
    
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
            Vector3 offset = Random.onUnitSphere * .32f;
            Vector3 spawnLocation = _earth.transform.position + offset;
            Vector3 direction = _earth.transform.position - spawnLocation;
            GameObject newDisaster = Instantiate(_disasterPrefabs[0], spawnLocation, Quaternion.identity);
            newDisaster.transform.parent = _earth.transform;
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
