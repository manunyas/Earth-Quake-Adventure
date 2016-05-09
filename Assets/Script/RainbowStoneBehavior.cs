using UnityEngine;
using System.Collections;

public class RainbowStoneBehavior : MonoBehaviour {
	public Transform rbstoneBodyx, rbstoneBodyy;
	public bool rbTouched;
	public float Speed, LifeTime;
	public GameObject rbstoneLife;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Behaviours ();

		//obj transition
		transform.position += Vector3.left * Time.deltaTime * Speed;

		//obj life time
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;

		//Obj stop motion
		if (DataCenter.instance.playerDataObject.EndStage == true) {
			Speed = 0f;
			Destroy(this.gameObject);
		}else if (DataCenter.instance.sceneDataObject.StartStage == false) {
			Speed = 0f;
			Destroy(this.gameObject);
		}
	
	}

	void RayCasting()
	{
		Debug.DrawLine (rbstoneBodyx.position,rbstoneBodyy.position,Color.green);
		rbTouched = Physics2D.Linecast (rbstoneBodyx.position,rbstoneBodyy.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours ()
	{
		if (rbTouched == true) {
			Destroy(this.gameObject);
			DataCenter.instance.playerDataObject.PointCount +=200; //reset everytime to start new stage
			DataCenter.instance.playerDataObject.exp += 200; //Add always game wake
		} else {
			rbstoneLife.SetActive (true);
		}
	}
}
