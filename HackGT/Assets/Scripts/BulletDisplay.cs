using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletDisplay : MonoBehaviour {

    public Image image;
    public Image[] bullets;
    GameObject player;
    int numBullets;
    PlayerFireController firecon;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        firecon = player.GetComponentInChildren<PlayerFireController>();
        //Image img = Instantiate(image);
        //img.transform.SetParent(transform.parent.gameObject.transform, false);
        Debug.Log(firecon);
        bullets = new Image[firecon.burstNum];
        for (int i = 0; i < bullets.Length; i++) {
            
            bullets[i] = Instantiate(image);
            bullets[i].transform.SetParent(transform.parent.gameObject.transform, false);
            bullets[i].transform.position = transform.position + new Vector3(30, 0 ,0) * i - new Vector3(35, 100,0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        numBullets = firecon.shotCount;
        for (int i = 0; i < bullets.Length; i++) {

            if (i < numBullets) {
                bullets[i].enabled = true;
            } else {
                bullets[i].enabled = false;
            }
        }

    }
}
