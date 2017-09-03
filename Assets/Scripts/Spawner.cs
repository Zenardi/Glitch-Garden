using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour {

    public GameObject[] attackersPrefabs;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    foreach(GameObject attacker in attackersPrefabs)
        {
            if(isTimeToSpawn(attacker))
            {
                Spawn(attacker);
            }
        }
	}

    private void Spawn(GameObject attacker)
    {
        GameObject atk = Instantiate(attacker) as GameObject;
        atk.transform.parent = transform;
        atk.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject attacker)
    {
        Attacker atk = attacker.GetComponent<Attacker>();

        float spawnDelay = atk.seenEverySeconds;
        float spawnsPerSecods = 1 / spawnDelay;

        if(Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threashHold = spawnsPerSecods * Time.deltaTime / 5;

        return (UnityEngine.Random.value < threashHold);
    }
}
