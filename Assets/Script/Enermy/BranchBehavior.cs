using UnityEngine;
using System.Collections;

public class BranchBehavior : MonoBehaviour {
	public float LifeTime, Speed;
	public bool BranchTouch;
	public Transform StartPoint, EndPoint;

	// Update is called once per frame
	void Update () {
		RayCasting ();
		transform.position += Vector3.left * Time.deltaTime * Speed;

		//Obj life time
		LifeTime -= Time.deltaTime;
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}

		//Obj stop motion
		if (DataCenter.instance.playerDataObject.currentHP < 0) {
			Speed = 0f;
			Destroy(this.gameObject);
		}else if (DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage) {
			Speed = 0f;
			Destroy(this.gameObject);
		}

	}

	void RayCasting ()
	{
		Debug.DrawLine (StartPoint.position,EndPoint.position,Color.blue);
		BranchTouch = Physics2D.Linecast (StartPoint.position, EndPoint.position, 1 << LayerMask.NameToLayer ("Player"));
	}

	
	/*void OnTriggerEnter2D(Collider2D collid)
	{
		if (collid.gameObject.tag == "Player") {
			//DataCenter.instance.playerDataObject.currentHP -= DataCenter.instance.playerDataObject.damage;
			BranchTouch = false;
		}
		
	}*/
}
