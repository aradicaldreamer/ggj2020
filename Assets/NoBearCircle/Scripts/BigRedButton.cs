using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRedButton : MonoBehaviour
{
    private Tool[] _tools;

    // Start is called before the first frame update
    void Start()
    {
        _tools = GameObject.FindObjectsOfType<Tool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ResetTools();
    }

    public void ResetTools()
    {
        for (int i = 0; i < _tools.Length; i++)
        {
            _tools[i].RespawnTool();
        }
    }
}
