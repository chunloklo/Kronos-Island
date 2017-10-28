using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    ParticleSystem explosiveParticles;
    public float timer;

    void Awake()
    {
        explosiveParticles = GetComponentInChildren<ParticleSystem>();
        explosiveParticles.Stop();
        //explosiveParticles.emission.enabled = false;
    }

    void Update() {
        timer -= GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
        if (timer <= 0) {
            explosiveParticles.Play();
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(explosiveParticles);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 10 || collision.gameObject.layer == 9) {
            explosiveParticles.Play();
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            //Destroy(explosiveParticles, 3);
        }
    }
}
