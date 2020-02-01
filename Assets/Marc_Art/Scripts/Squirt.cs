using UnityEngine;

public class Squirt : OVRGrabbable
{
    public ParticleSystem sprayParticles;
    public Animator sprayAnimator;
    public Material liquidShader;

    public float bulletSpeed = 20;
    public Rigidbody bullet;
    public int lifetime = 1;

    override public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
    }

    override public void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }

    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
        Destroy(bulletClone.gameObject, lifetime);
    }

    void Update()
    {
        if (isGrabbed)
        {
            var controller = grabbedBy.name == "LeftHandAnchor" ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch;
            var trigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, controller);
            if (trigger > 0.5f)
            {
                sprayAnimator.SetBool("Trigger", true);
                if (!sprayParticles.isPlaying) sprayParticles.Play();
                Fire();
                // play sound
            }
            else
            {
                sprayAnimator.SetBool("Trigger", false);
                if (sprayParticles.isPlaying) sprayParticles.Stop();
            }
        }
        else
        {
            sprayAnimator.SetBool("Trigger", false);
            if (sprayParticles.isPlaying) sprayParticles.Stop();
        }
    }
}
