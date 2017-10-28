using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate;
    public float timer;

    // Use this for initialization
    void Start () {
        float delay = Random.Range(0, .5f);



        if (gameObject.name == "Grenade Enemy")
        {
            bulletPrefab = (GameObject)Resources.Load("Prefab/Grenade");
            bulletSpawn = transform.Find("Gunpoint");
            timer = delay;
        }
        else
        {
            bulletPrefab = (GameObject)Resources.Load("Prefab/Bullet");
            bulletSpawn = transform.Find("Gunpoint");
            timer = delay;
        }
	}
	
	// Update is called once per frame
	void Update () {

        timer += GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
        if (timer > 1 / fireRate) {
            if (gameObject.name == "Grenade Enemy") {
                GrenadeFire();
            } else {
                Fire();
            }
            timer = 0f;
        }
	}

    void Fire() {
        GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        bullet.GetComponent<BulletController>().SetOwner(gameObject);
    }

    void GrenadeFire() {
        GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        //bullet.GetComponent<BulletController>().SetOwner(gameObject);
    }

}
