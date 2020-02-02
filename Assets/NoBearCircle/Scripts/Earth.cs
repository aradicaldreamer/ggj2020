using UnityEngine;

public class Earth : OVRGrabbable
{
    public AudioSource audioSource;
    public new Rigidbody rigidbody;


	override public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        m_grabbedBy = hand;
        m_grabbedCollider = grabPoint;
    }
    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        m_grabbedBy = null;
        m_grabbedCollider = null;
    }

    private void Start()
    {

    }

    private void Update()
    {

    }
}