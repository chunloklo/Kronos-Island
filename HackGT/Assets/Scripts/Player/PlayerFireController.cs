using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate;
    private float timer;

    // Use this for initialization
    void Start() {
        bulletPrefab = (GameObject)Resources.Load("Prefab/PlayerBullet");
        bulletSpawn = transform;
        timer = 0f;
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
    }


    public void Fire() {
        if (timer <= 0) {
            GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<BulletController>().SetOwner(transform.parent.gameObject);
            timer = 1 / fireRate;
        }
        
    }
}
