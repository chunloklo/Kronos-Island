using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public float timeScale = 1;
    public float normalTime = 1;
    public float slowTime = .3f;
    public bool timeStop;
    public AudioSource timeStopMusic;
    public AudioSource normalTimeMusic;
    // Use this for initialization
    void Start () {
        timeStop = false;
        normalTimeMusic.loop = true;
        timeStopMusic.Play();
        timeStopMusic.Pause();
        timeStopMusic.loop = true;
        normalTimeMusic.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public float DeltaTime() {
        return Time.deltaTime * timeScale;
    }

    public void SwitchTime() {
        if (timeScale == slowTime) {
            normalTimeMusic.UnPause();
            timeStopMusic.Pause();
            timeStop = false;
            timeScale = normalTime;
        } else {
            normalTimeMusic.Pause();
            timeStopMusic.UnPause();
            timeStop = true;
            timeScale = slowTime;
        }
    }

    public bool Stopped() {
        return timeStop;
    }


}
