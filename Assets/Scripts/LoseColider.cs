﻿using UnityEngine;
using System.Collections;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;
	// Use this for initialization
	void Start () {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnTriggerEnter2D()
    {
        levelManager.LoadLevel("03b Lose");
    }
}
