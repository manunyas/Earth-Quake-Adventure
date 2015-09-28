using UnityEngine;
using System.Collections;

public class JumpRaycast : MonoBehaviour {
	public bool grounded = false;
	public bool jumped = false;
	public float jumpHeight,jumpTime;
	public Transform groundedEnd;

	Rigidbody2D rd;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Movement ();
	
	}

	void RayCasting () {
		//Debug.DrawLine(this.transform.position, groundedEnd.position,Color.red);
		grounded = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 <<LayerMask.NameToLayer("Ground"));

	}

	void Movement ()
	{
		if (Input.GetKeyDown("space") && grounded == true) {
			rd.AddForce (Vector2.up * jumpHeight,ForceMode2D.Impulse);
			jumpTime -= Time.deltaTime;
		}

	}

}
