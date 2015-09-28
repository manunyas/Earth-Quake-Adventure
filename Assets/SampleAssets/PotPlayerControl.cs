using UnityEngine;
using System.Collections;

public class PotPlayerControl : MonoBehaviour {
	
	Rigidbody2D rb;
	public float jumpHeight;
	public bool isGrounded = false;
	
	public float jumpTime,jumpDelay = .2f;
	public bool jumped;
	
	public Transform groundPoint;
	public Transform bodyPoint;
	public Transform PlayerPosition;
	public Vector3 PlayerVector3;
	
	
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
		PlayerPosition = gameObject.GetComponent<Transform> ();
		PlayerVector3 = PlayerPosition.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		PlayerVector3.y = PlayerPosition.position.y;
		Raycasting ();
		Movement (); 
	}
	
	void Raycasting()
	{
		isGrounded = Physics2D.Linecast (bodyPoint.position, groundPoint.position);
		if (isGrounded) {
			transform.Translate (-0.00f, 0, 0);
		}
		
	}
	
	void Jump()
	{
		if (!isGrounded)
		{
			return;
		}
		jumped = true;
		jumpTime = jumpDelay;
		isGrounded = false;
		Vector2 jumeMovement = new Vector2(0f, 1);
		rb.AddForce (jumeMovement * jumpHeight,ForceMode2D.Impulse);
	}
	
	void Movement()
	{		
		if (Input.GetKeyDown ("space") && isGrounded)
		{
			Jump ();
		}
		jumpTime -= Time.deltaTime;
		
		if (jumpTime <= 0 && isGrounded && jumped) 
		{
			jumped = false;
		}
	}
}
