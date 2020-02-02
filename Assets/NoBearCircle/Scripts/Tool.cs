using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public Vector3 respawnLocation;
    public Quaternion respawnRotation;
    private Rigidbody _rigidbody;
    
    void Awake()
    {
        respawnLocation = this.transform.position;
        respawnRotation = this.transform.rotation;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody not found on " + this.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnTool()
    {
        this.transform.position = respawnLocation;
        this.transform.rotation = respawnRotation;
        this._rigidbody.velocity = Vector3.zero;
        this._rigidbody.angularVelocity = Vector3.zero;
    }
}
