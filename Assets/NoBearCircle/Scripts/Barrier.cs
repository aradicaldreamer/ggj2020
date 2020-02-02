using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Tool tool = other.GetComponent<Tool>();
        if (tool != null)
        {
            tool.RespawnTool();
        }
    }
}
