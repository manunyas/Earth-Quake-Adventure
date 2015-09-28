using UnityEngine;
using System.Collections;

public class CoinBehavior : MonoBehaviour {

	public Transform CoinBody;
	public Transform CoinDetect;
	public bool Detected;
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
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;
	
	}

	void RayCasting ()
	{
		//Debug.DrawLine (CoinBody.position,CoinDetect.position,Color.red);
		Detected = Physics2D.Linecast (CoinBody.position,CoinDetect.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours ()
	{
		if (Detected == true) {
			Destroy(this.gameObject);
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
