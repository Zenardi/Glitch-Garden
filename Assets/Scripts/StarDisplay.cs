﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text startText;
    private int stars = 100;
    public enum Status { SUCCESS, FAILURE }

	// Use this for initialization
	void Start () {
        startText = GetComponent<Text>();
        UpdateDisplay();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();

            return Status.SUCCESS;
        }

        return Status.FAILURE;

    }

    private void UpdateDisplay()
    {
        startText.text = stars.ToString();
    }
}