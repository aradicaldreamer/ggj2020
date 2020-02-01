using UnityEngine;

public class Earth : OVRGrabbable
{
    /// <summary>
	/// Notifies the object that it has been grabbed.
	/// </summary>
	override public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        m_grabbedBy = hand;
        m_grabbedCollider = grabPoint;
    }

    /// <summary>
    /// Notifies the object that it has been released.
    /// </summary>
    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        m_grabbedBy = null;
        m_grabbedCollider = null;
    }
}