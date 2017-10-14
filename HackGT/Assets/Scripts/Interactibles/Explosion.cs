using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    ParticleSystem explosiveParticles;

    void Awake()
    {
        explosiveParticles = GetComponentInChildren<ParticleSystem>();
        explosiveParticles.Stop();
        //explosiveParticles.emission.enabled = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.layer == 9)
        {
            explosiveParticles.Play();
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            //Destroy(explosiveParticles, 3);
        }
    }
}
