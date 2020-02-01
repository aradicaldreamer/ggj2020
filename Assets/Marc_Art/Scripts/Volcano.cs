using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cork")
        {
            Destroy(gameObject);
        }
    }
}
