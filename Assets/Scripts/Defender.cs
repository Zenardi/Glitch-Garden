﻿using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    public int starCost = 100;
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStarts(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
