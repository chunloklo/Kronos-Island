using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float reloadTime;
    public float timer;
    public float freezeTime;
    public float freezeTimer;
    public int burstNum;
    public int shotCount;
    public bool firemode;

    // Use this for initialization
    void Start() {
        bulletPrefab = (GameObject)Resources.Load("Prefab/PlayerBullet");
        bulletSpawn = transform;
        timer = 0f;
        shotCount = 0;
        firemode = false;
    }

    // Update is called once per frame
    void Update() {

        //initiate freezetime
        if (Input.GetMouseButtonDown(1) && !firemode && timer < 0) {
            Debug.Log("switch");
            GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
            firemode = true;
            shotCount = burstNum;
            freezeTimer = freezeTime;
        }

        //if (Input.GetMouseButtonDown(1) && firemode) {
        //    GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
        //    firemode = false;
        //    timer = reloadTime;
        //}

        if (!firemode) {
            timer -= GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
        }

        if (firemode) {
            freezeTimer -= Time.deltaTime;
            if (Input.GetMouseButtonDown(0)) {
                Fire();
            }
        }

        if (shotCount == 0 && firemode) {
            GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
            timer = reloadTime;
            firemode = false;
        }

        if (freezeTimer <= 0 && firemode) {
            GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
            timer = reloadTime;
            firemode = false;
        }
    }


    public void Fire() {
        if (shotCount > 0) {
            GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<BulletController>().SetOwner(transform.parent.gameObject);
            bullet.GetComponent<BulletController>().movementSpeed = 0;
            shotCount = shotCount - 1;
            
        }
    }
}
