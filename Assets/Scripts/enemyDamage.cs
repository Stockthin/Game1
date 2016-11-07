using UnityEngine;
using System.Collections;

public class enemyDamage : MonoBehaviour {
    public float damage;
    public float dameRate;
    public float pushBackForce;
    float NextDamage;
	// Use this for initialization
	void Start () {
        NextDamage = 0f;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && NextDamage < Time.time)
        {
            playerHealth thePlayerHealth = other.gameObject.GetComponent<playerHealth>();
            thePlayerHealth.addDame(damage);
            NextDamage = Time.time + dameRate;
            pushBack(other.transform);
        }
    }
    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(0, (pushedObject.position.y - transform.position.y)).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
