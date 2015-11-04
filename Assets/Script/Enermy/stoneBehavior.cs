using UnityEngine;
using System.Collections;

public class stoneBehavior : MonoBehaviour {
	public float LifeTime,speed;
	public Transform StartPoint, EndPoint;
	public bool StoneTouched;

	void Update () 
	{
		RayCasting ();
		//Damge ();
		transform.position += Vector3.left * Time.deltaTime * speed;
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;
	}

	void RayCasting ()
	{
		Debug.DrawLine (StartPoint.position,EndPoint.position,Color.blue);
		StoneTouched = Physics2D.Linecast (StartPoint.position, EndPoint.position, 1 << LayerMask.NameToLayer ("Player"));
	}

	/*void Damage ()
	{
		if (StoneTouched == true) {
			DataCenter.instance.playerDataObject.currentHP -= DataCenter.instance.playerDataObject.damage;
			StoneTouched = false;
		}
	}*/
	
	void OnTriggerEnter2D(Collider2D collid)
	{
		if (collid.gameObject.tag == "Player") {
			DataCenter.instance.playerDataObject.currentHP -= DataCenter.instance.playerDataObject.damage;
			//StoneTouched = false;
		}
		
	}
}
