using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirt : MonoBehaviour
{
    public ParticleSystem sprayParticles;
    public Animator sprayAnimator;
    public Material liquidShader;

    public float bulletSpeed = 20;
    public Rigidbody bullet;
    public int lifetime = 1;

    void Fire()
    {
        Rigidbody bulletClone = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletClone.velocity = transform.forward * bulletSpeed;
        Destroy(bulletClone.gameObject, lifetime);
    }

    void Update()
    {
        // Switch the input to the Oculus input. E is a test input
        if (Input.GetKeyDown("e"))
        {
            sprayAnimator.SetBool("Trigger", true);
            sprayParticles.Play();
            Fire();
            // play sound
        }
        else if (Input.GetKeyUp("e")){
            sprayAnimator.SetBool("Trigger", false);
        }
    }
}
