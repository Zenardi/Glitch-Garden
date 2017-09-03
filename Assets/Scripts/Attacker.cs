using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Tooltip("Avg number of seconds between spawn")]
    public float seenEverySeconds;

    private float currentSpeed = 0f;
    private GameObject currentTarget;
    private Animator animator;
    
    // Use this for initialization
	void Start () {
        //Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
        //rigidBody.isKinematic = true;
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            animator.SetBool("isAttacking", false);
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("trigger Enter " + name);
    }

    public void setSpeed(float speed)
    {
        currentSpeed = speed;
    }

    /// <summary>
    /// Called from the animator at time of actual blow
    /// </summary>
    /// <param name="damage"></param>
    public void StrikeCurrentTarget(float damage)
    {
        if(currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
            {
                health.DealDamage(damage);
            }
        }
            
        //Debug.Log("Damage caused: " + damage);
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
