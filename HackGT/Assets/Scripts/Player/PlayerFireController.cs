using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate;
    public float timer;
    public int burstNum;
    public int shotCount;

    // Use this for initialization
    void Start() {
        bulletPrefab = (GameObject)Resources.Load("Prefab/PlayerBullet");
        bulletSpawn = transform;
        timer = 0f;
        shotCount = burstNum;
    }

    // Update is called once per frame
    void Update() {
        timer -= GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
    }


    public void Fire() {
        if (timer <= 0) {
            GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<BulletController>().SetOwner(transform.parent.gameObject);
            bullet.GetComponent<BulletController>().movementSpeed = 0;
            shotCount = shotCount - 1;
            
        }
        
        if (shotCount <= 0) {
            timer = 1 / fireRate;
            shotCount = burstNum;
        }
    }
}
