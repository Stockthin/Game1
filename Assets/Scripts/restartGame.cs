﻿using UnityEngine;
using System.Collections;

public class restartGame : MonoBehaviour {
    public float restartTime;
    bool restartNow = false;
    float resetTime;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(restartNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	
	}
    public void restartTheGame()
    {
        restartNow = true;
        resetTime = Time.time + restartTime;
    }
}
