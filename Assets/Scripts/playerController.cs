using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float maxSpeed;
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;
	Rigidbody2D myRB;
	Animator myAnim;
	bool facingright;
    public Transform GunTip;
    public GameObject bullet;
    public float fireRate = 0.5f;
    float nextFire = 0f;
    
    
	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
		facingright = true;
        
	}
	void Update(){
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false;
			myAnim.SetBool ("isGrounded", grounded);
			myRB.AddForce(new Vector2(0, jumpHeight));
		}
        if (Input.GetAxisRaw("Fire1") > 0) fireShuriken();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		myAnim.SetBool ("isGrounded", grounded);
		myAnim.SetFloat ("verticalSpeed", myRB.velocity.y);	
		float move = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (move));
		myRB.velocity = new Vector2 (move * maxSpeed, myRB.velocity.y);
		if (move>0&&!facingright){
			flip ();
	
	}
		else if(move<0&&facingright){
			flip ();
			
			
}
	}
	void flip(){
		facingright = !facingright;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
}
    void fireShuriken()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingright)
            {
                Instantiate(bullet, GunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingright)
            {
                Instantiate(bullet, GunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
       
    }
}
