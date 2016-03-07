using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour {
	public bool grounded = false;
	public bool shooted = false;
	public bool hit = false;
	public bool hitSpecial = false;
	public Transform groundedPoint,endPoint;
	public Animator anim;
	public int jumpCount;
	Rigidbody2D rd;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
	
	}

	void RayCasting () 
	{
		//Debug.DrawLine(this.transform.position, groundedEnd.position,Color.red);
		Debug.DrawLine(this.transform.position, groundedPoint.position,Color.red);
		Debug.DrawLine (this.transform.position,endPoint.position,Color.green);

		//Touched the ground
		grounded = Physics2D.Linecast (this.transform.position, groundedPoint.position, 1 <<LayerMask.NameToLayer("Ground"));
		//Hit Enermy type obj
		hit = Physics2D.Linecast (this.transform.position, endPoint.position, 1 << LayerMask.NameToLayer ("Enermy"));
		//Hit Special Enermy obj or special Obj
		hitSpecial = Physics2D.Linecast (this.transform.position,endPoint.position, 1<<LayerMask.NameToLayer("EnermySP"));
		hitSpecial = Physics2D.Linecast (this.transform.position,endPoint.position, 1<<LayerMask.NameToLayer("SpecialLayer"));
	}

	public void ShootingBool()
	{
		anim.SetBool ("isShoot1", true);
	}

	public void ShootingTrigger()
	{
		anim.SetTrigger ("isShoot2");
	}
}
