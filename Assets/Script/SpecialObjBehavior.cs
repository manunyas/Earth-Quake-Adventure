using UnityEngine;
using System.Collections;

public class SpecialObjBehavior : MonoBehaviour {
	public Transform headPoint, endPoint;
	public bool ObjTouched = false;
	public float Speed, LifeTime;
	public GameObject ObjLife;
	public int ObjPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		ObjectBehaviour ();

		transform.position += Vector3.left * Time.deltaTime * Speed;

		//obj life time
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;

		//Stop Motion
		//Obj stop motion

		if (DataCenter.instance.playerDataObject.EndStage == true) {
			Speed = 0f;
			Destroy(this.gameObject);
		}else if (DataCenter.instance.sceneDataObject.StartStage == false) {
			Speed = 0f;
			Destroy(this.gameObject);
		}
	
	}

	void RayCasting ()
	{
		Debug.DrawLine (headPoint.position,endPoint.position,Color.magenta);
		ObjTouched = Physics2D.Linecast (headPoint.position,endPoint.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void ObjectBehaviour ()
	{
		if (ObjTouched == true) {
			Destroy(this.gameObject);
			DataCenter.instance.playerDataObject.CoinCount +=1;
			DataCenter.instance.playerDataObject.PointCount +=ObjPoint;
		} else {
			ObjLife.SetActive (true);
		}
	}
}
