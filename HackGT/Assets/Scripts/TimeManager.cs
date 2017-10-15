using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public float timeScale = 1;
    public float normalTime = 1;
    public float slowTime = .3f;
    public bool timeStop;
    AudioSource audio;
    // Use this for initialization
    void Start () {
        timeStop = false;
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float DeltaTime() {
        return Time.deltaTime * timeScale;
    }

    public void SwitchTime() {
        if (timeScale == slowTime) {
            audio.Stop();
            timeStop = false;
            timeScale = normalTime;
        } else {
            audio.Play();
            timeStop = true;
            timeScale = slowTime;
        }
    }

    public bool Stopped() {
        return timeStop;
    }


}
