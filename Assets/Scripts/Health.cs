using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour {

    public float health = 100f;


    internal void DealDamage(float damage)
    {
        health -= damage;
        if(health<=0)
        {
            ///Trigger animation: die state

            DestroyObject();
        }
    }

    public void DestroyObject()
    {

        Destroy(gameObject);
    }
}
