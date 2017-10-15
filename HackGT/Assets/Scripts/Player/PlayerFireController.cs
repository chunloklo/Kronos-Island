using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    public AudioSource gunShot;
    public AudioSource gunCharge;
    public AudioSource recharged;
    private Boolean played;

    //UI
    public Text bulletCount;
    public Text time;

    // Use this for initialization
    void Start() {
        bulletPrefab = (GameObject)Resources.Load("Prefab/PlayerBullet");
        bulletSpawn = transform;
        timer = 0f;
        shotCount = 0;
        firemode = false;
        //bulletCount.text = "" + shotCount + "/" + burstNum;
    }

    // Update is called once per frame
    void Update() {

        if (timer < 0 && !played && !firemode) {
            recharged.Play();
            played = true;
            
        }


        //initiate freezetime
        if (Input.GetMouseButtonDown(1) && !firemode && timer < 0) {
            //Debug.Log("switch");
            GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
            firemode = true;
            shotCount = burstNum;
            timer = reloadTime;
            freezeTimer = freezeTime;
        } else if (Input.GetMouseButtonDown(1) && firemode) {
            GameObject.Find("TimeManager").GetComponent<TimeManager>().SwitchTime();
            firemode = false;
            timer = reloadTime;
            shotCount = 0;
        }

        bulletCount.text = "" + shotCount + "/" + burstNum;
        time.text = "" + Math.Round(freezeTimer, 2) + "s";
        if (Math.Round(freezeTimer, 2) < 0)
        {
            time.text = 0 + "" + "s";
        }
        bulletCount.enabled = true;
        time.enabled = true;

        if (!firemode) {
            timer -= GameObject.Find("TimeManager").GetComponent<TimeManager>().DeltaTime();
            bulletCount.enabled = false;
            time.enabled = false;
        }

        if (firemode) {
            freezeTimer -= Time.deltaTime;
            if (Input.GetMouseButtonDown(0)) {
                Fire();
            }
            bulletCount.enabled = true;
            time.enabled = true;
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
            shotCount = 0;
        }
    }


    public void Fire() {
        if (shotCount > 0) {
            gunShot.Play();
            GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
            bullet.GetComponent<PlayerBulletController>().SetOwner(transform.parent.gameObject);
            bullet.GetComponent<PlayerBulletController>().movementSpeed = 0;
            shotCount = shotCount - 1;
            played = false;

        }
    }
}
