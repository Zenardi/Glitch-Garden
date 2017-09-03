using UnityEngine;
using System.Collections;
using System;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner laneSpawner;

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }

	// Use this for initialization
	void Start () {
        animator = FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        /// Creates a parent if necessary
	    if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
	}
	
	// Update is called once per frame
	void Update () {
	    if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
            animator.SetBool("isAttacking", false);
    }

    /// <summary>
    /// Look though all spawners and set lanespawner if found
    /// </summary>
    void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner s in spawnerArray)
        {
            if(s.transform.position.y ==  transform.position.y)
            {
                laneSpawner = s;
                return;
            }
        }

        Debug.LogError(name + "Cant find spawner");
    }

    private bool IsAttackerInLane()
    {
        ///Exist if no attacker
        if (laneSpawner.transform.childCount <= 0)
            return false;

        ///If thre are attackers
        foreach(Transform attacker in laneSpawner.transform)
        {
            if(attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        ///attacker in lane, but behind!
        return false;
    }
}
