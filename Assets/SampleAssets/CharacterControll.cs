using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterControll : MonoBehaviour {
	public float maxSpeed = 10f;
	bool facingRight = true;
	public float jumpHeight;

	Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	  
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Check the ground
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


		//Move right-left
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		GetComponent<Rigidbody2D>().velocity = new Vector2(move*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		 if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		} 
	}
	void Update()
	{
		if (grounded && Input.GetKeyDown(KeyCode.Space)) {
			anim.SetBool("Ground",false);
			Vector2 jumpMovement = new Vector2(0f,1);
			GetComponent<Rigidbody2D>().AddForce(jumpMovement*jumpHeight,ForceMode2D.Impulse);
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
