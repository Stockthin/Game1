using UnityEngine;
using System.Collections;

public class ShurikenHit : MonoBehaviour {
    public float WeaponDame;
    ProjectileController myPC;
    public GameObject ExplosionEffect;

	// Use this for initialization
	void Awake () {
        myPC = GetComponentInParent<ProjectileController>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPC.removeForce();
            Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDame(WeaponDame);

            }
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
        {
            myPC.removeForce();
            Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDame(WeaponDame);

            }
        }

    }
}
