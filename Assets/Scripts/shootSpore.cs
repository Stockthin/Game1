using UnityEngine;
using System.Collections;

public class shootSpore : MonoBehaviour {
    public GameObject theProjectile;
    public float shootTime;
    public int changeShoot;
    public Transform shootFrom;
    float nextShootTime;
    Animator canonAmin;

	// Use this for initialization
	void Start () {
        canonAmin = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
        /*if (Random.Range(0, 10) >= changeShoot)
        {
            Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
            canonAmin.SetTrigger("canShoot");
        }*/
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= changeShoot)
            {
                Instantiate(theProjectile, shootFrom.position, Quaternion.identity);
                canonAmin.SetTrigger("canonShoot");
            }
        }
    }
}
