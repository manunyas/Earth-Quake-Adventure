using UnityEngine;
using System.Collections;

public class Player2Control : MonoBehaviour {
	public bool grounded, hit, hitSpecial;
	public Transform groundedPoint,endPoint;
	public Animator anim;
	public int jumpCount;
	public float jumpHeight;
	Rigidbody2D rd;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Hiting ();
	
	}

	void RayCasting () 
	{
		//Debug.DrawLine(this.transform.position, groundedEnd.position,Color.red);
		Debug.DrawLine(this.transform.position, groundedPoint.position,Color.yellow);
		Debug.DrawLine (this.transform.position,endPoint.position,Color.green);

		//Touched the ground
		grounded = Physics2D.Linecast (this.transform.position, groundedPoint.position, 1 <<LayerMask.NameToLayer("Ground"));

		//Hit Enermy type obj
		hit = Physics2D.Linecast (this.transform.position, groundedPoint.position, 1 << LayerMask.NameToLayer ("Enermy"));
		//Hit Special Enermy obj or special Obj
		hitSpecial = Physics2D.Linecast (this.transform.position,groundedPoint.position, 1<<LayerMask.NameToLayer("EnermySP"));
		hitSpecial = Physics2D.Linecast (this.transform.position,endPoint.position, 1<<LayerMask.NameToLayer("SpecialLayer"));
	}

	//Button action
	public void ShootingTrigger()
	{
		anim.SetTrigger ("isShoot2");
	}

	public void PressJump ()
	{
		if (grounded == true) {
			rd.AddForce (Vector2.up * jumpHeight,ForceMode2D.Impulse);
			jumpCount +=1;
		}else if (jumpCount > 0){
			rd.AddForce (Vector2.up * jumpHeight/2,ForceMode2D.Impulse);
			jumpCount = 0;
		}
	}
	//

	void Hiting()
	{
		if (hit == true) {
			GetComponent<SpriteRenderer> ().color = Color.red;
			DataCenter.instance.playerDataObject.Hit = true;
			DataCenter.instance.playerDataObject.currentHP -= DataCenter.instance.playerDataObject.damage;
		} else {
			GetComponent<SpriteRenderer> ().color = Color.white;
			DataCenter.instance.playerDataObject.Hit = false;
		}
	}

}
