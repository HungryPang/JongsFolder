﻿using UnityEngine;
using System.Collections;

public class hpGage : Gage {
    public bool isGameOver
    {
        get { return rateOfGage >= 1.0f; }
    }
	// Use this for initialization
	void Start () {
        value = 0;
        nowScale = initScale = transform.localScale;
        increaseGagePerSecond = 5.0f;
        //GetComponent<SpriteRenderer>().color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        GageFluctuation(Time.deltaTime * increaseGagePerSecond);

        float t = rateOfGage;
        nowScale.y = t * initScale.y;
        transform.localScale = nowScale;
    }
}
