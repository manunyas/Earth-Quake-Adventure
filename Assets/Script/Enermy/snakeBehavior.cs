using UnityEngine;
using System.Collections;

public class snakeBehavior : MonoBehaviour {
	public float LifeTime,speed;
	public Transform xPosition, yPosition;
	public bool SnakeTouched;

	// Update is called once per frame
	void Update () {
		RayCasting ();

		//Moving
		transform.position += Vector3.left * Time.deltaTime * speed;

		//Time to appear
		if (LifeTime <= 0) {
			Destroy(this.gameObject);
		}
		LifeTime -= Time.deltaTime;

		//Stop Motion
		if (DataCenter.instance.playerDataObject.EndStage == true) {
			speed = 0f;
			Destroy(this.gameObject);
		}else if (DataCenter.instance.sceneDataObject.StartStage == false) {
			speed = 0f;
			Destroy(this.gameObject);
		}
	
	}

	void RayCasting()
	{
		Debug.DrawLine (xPosition.position,yPosition.position,Color.blue);
		SnakeTouched = Physics2D.Linecast (xPosition.position,yPosition.position, 1 << LayerMask.NameToLayer ("Player"));
	}
}
