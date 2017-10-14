using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate;
    private float timer;

    // Use this for initialization
    void Start () {
        bulletPrefab = (GameObject) Resources.Load("Prefab/Bullet");
        bulletSpawn = transform.Find("Gunpoint");
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
        if (timer > 1 / fireRate) {
            Fire();
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
}
