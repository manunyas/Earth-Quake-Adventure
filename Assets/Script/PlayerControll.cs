using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {
	public bool grounded = false;
	public bool hit = false;
	public float jumpHeight;
	public Transform groundedEnd;
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
		Movement ();
		Hit ();
		
		//Stop motion when die or complete mission or dont start stage
		if (DataCenter.instance.playerDataObject.EndStage == true) {
			anim.Stop();
		}
	}

	void RayCasting () {
		Debug.DrawLine(this.transform.position, groundedEnd.position,Color.red);

		//Touched the ground
		grounded = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 <<LayerMask.NameToLayer("Ground"));
		//Hit Enermy type obj
		hit = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer ("Enermy"));
	}

	void Movement ()
	{
		if (Input.GetKeyDown ("space") && grounded == true) {
			rd.AddForce (Vector2.up * jumpHeight, ForceMode2D.Impulse);
			jumpCount += 1;
		} else if (Input.GetKeyDown ("space") && jumpCount > 0) {
			rd.AddForce (Vector2.up * 8f, ForceMode2D.Impulse);
			jumpCount = 0;
		}

		/*if (Input.GetKey (KeyCode.DownArrow) && grounded == true) {
			anim.SetBool ("isSlide", true);
		} else {
			anim.SetBool ("isSlide", false);
		}*/
		
	}

	//For Button
	public void Jump ()
	{
		if (grounded == true) {
			rd.AddForce (Vector2.up * jumpHeight,ForceMode2D.Impulse);
			jumpCount +=1;
		}else if (jumpCount > 0){
			rd.AddForce (Vector2.up * jumpHeight/2,ForceMode2D.Impulse);
			jumpCount = 0;
		}
	}

	public void SlideDown()
	{
			anim.SetTrigger("isSliding");
	}

	public void SlideUp()
	{
			anim.SetTrigger("isSliding");
	}
	//

	void Hit()
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
