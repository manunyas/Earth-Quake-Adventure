﻿using UnityEngine;
using System.Collections;

public class stoneBehavior : MonoBehaviour {
	public float LifeTime;
	public float speed;
	public Transform StartPoint, EndPoint;
	public bool StoneTouched;

	void Update () 
	{
		RayCasting ();
		//Touched ();

		transform.position += Vector3.left * Time.deltaTime * speed;
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;
	}

	void RayCasting ()
	{
		//Debug.DrawLine (StartPoint.position,EndPoint.position,Color.blue);
		StoneTouched = Physics2D.Linecast (StartPoint.position, EndPoint.position, 1 << LayerMask.NameToLayer ("Player"));
	}

	void Touched ()
	{
		if (StoneTouched == true) {
			//Time.timeScale = 0;
			DataCenter.instance.playerDataObject.currentTime -= DataCenter.instance.playerDataObject.damage;
			StoneTouched = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D collid)
	{
		if (collid.gameObject.tag == "Player") {
			DataCenter.instance.playerDataObject.currentTime -= DataCenter.instance.playerDataObject.damage;
			StoneTouched = false;
			Debug.Log ("why wont you work ;_;");
		}
		
	}
}
