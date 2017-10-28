using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {
    public float movementSpeed;
    private float timePassed;
    public float timeAlive;
    public int damage;
    ParticleSystem explosiveParticles;

    void Awake() {
        explosiveParticles = GetComponentInChildren<ParticleSystem>();
        explosiveParticles.Stop();
        //explosiveParticles.emission.enabled = false;
    }

    void Start()
    {
        timeAlive = 5;
        timePassed = 0f;
        damage = 15;
    }

    void Update()
    {
        transform.position += transform.forward * GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime() * movementSpeed;
        timePassed += GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
        if (timePassed >= timeAlive)
        {
            Destroy(gameObject);
        }
        detonateGrenade();
    }

    void detonateGrenade()
    {
        Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 2);
        foreach(Collider col in hitColliders)
        {
            if (col.gameObject.tag == "Player")
            {
                explosiveParticles.Play();
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
        }
    }
}
