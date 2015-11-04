using UnityEngine;
using System.Collections;

public class JumpRaycast : MonoBehaviour {
	public bool grounded = false;
	public bool jumped = false,hit = false;
	public float jumpHeight;
	public int jumpTime;
	public Transform groundedEnd;
	public Animator anim;

	Rigidbody2D rd;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Movement ();
		Hit ();

		//Stop motion when die or complete mission
		if (DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage) {
			anim.Stop();
		}
		if (DataCenter.instance.playerDataObject.currentHP < 0) {
			anim.Stop ();
		}
	}

	void RayCasting () {
		Debug.DrawLine(this.transform.position, groundedEnd.position,Color.red);
		//touched the ground
		grounded = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 <<LayerMask.NameToLayer("Ground"));
		//Hit Enermy type obj
		hit = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer ("Enermy"));
	}

	void Movement ()
	{
		if (Input.GetKeyDown("space") && grounded == true) {
			rd.AddForce (Vector2.up * jumpHeight,ForceMode2D.Impulse);
			jumpTime = 1;
		}

	}

	public void Jump ()
	{
		if (grounded == true) {
			rd.AddForce (Vector2.up * jumpHeight,ForceMode2D.Impulse);
			jumpTime = 1;
		}
	}

	void Hit()
	{
		if (hit == true) {
			GetComponent<SpriteRenderer> ().color = Color.red;
			DataCenter.instance.playerDataObject.Hit = true;
		} else {
			GetComponent<SpriteRenderer> ().color = Color.white;
			DataCenter.instance.playerDataObject.Hit = false;
		}
	}

}
