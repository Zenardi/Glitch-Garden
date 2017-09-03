using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damege;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker atk = collider.gameObject.GetComponent<Attacker>();
        Health h = collider.gameObject.GetComponent<Health>();

        if(atk && h)
        {
            h.DealDamage(damege);
            Destroy(gameObject);
        }

    }
}
