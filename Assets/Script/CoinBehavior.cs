using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {

	public Transform CoinBody;
	public Transform CoinDetect;
	public bool CoinTouched;
	public float Speed, LifeTime;
	public GameObject coinLife;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		RayCasting ();
		Behaviours ();

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
		//Debug.DrawLine (CoinBody.position,CoinDetect.position,Color.red);
		CoinTouched = Physics2D.Linecast (CoinBody.position,CoinDetect.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours ()
	{
		if (CoinTouched == true) {
			Destroy(this.gameObject);
			DataCenter.instance.playerDataObject.CoinCount +=1;
			DataCenter.instance.playerDataObject.PointCount +=10;
		} else {
			coinLife.SetActive (true);
		}
	}

	/*void OnTriggerEnter2D(Collider2D collid)
	{
		if (collid.tag=="Player") {
			Time.timeScale = 0;
		}
		
	}*/

}
