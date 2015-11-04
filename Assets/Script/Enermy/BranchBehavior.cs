using UnityEngine;
using System.Collections;

public class BranchBehavior : MonoBehaviour {
	public float LifeTime, Speed;
	public bool BranchTouch;
	public Transform StartPoint, EndPoint;

	// Update is called once per frame
	void Update () {
		RayCasting ();
		//Damage ();
		transform.position += Vector3.left * Time.deltaTime * Speed;
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;

	}

	void RayCasting ()
	{
		//Debug.DrawLine (StartPoint.position,EndPoint.position,Color.blue);
		BranchTouch = Physics2D.Linecast (StartPoint.position, EndPoint.position, 1 << LayerMask.NameToLayer ("Player"));
	}

	/*void Damage()
	{
		if (BranchTouch == true) {
			DataCenter.instance.playerDataObject.currentHP -= DataCenter.instance.playerDataObject.damage;
			//BranchTouch = false;
		}
	}*/

	void OnTriggerEnter2D(Collider2D collid)
	{
		if (collid.gameObject.tag == "Player") {
			DataCenter.instance.playerDataObject.currentHP -= DataCenter.instance.playerDataObject.damage;
			BranchTouch = false;
		}
		
	}
}
