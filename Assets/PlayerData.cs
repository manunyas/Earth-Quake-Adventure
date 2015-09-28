using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
	public bool isTimeOut = false;
	public float maxTime;
	public float damage;
	public float currentTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		currentTime -= Time.deltaTime;
		if (currentTime == 0 && currentTime < 0) {

			isTimeOut = true;
		}
	}
}
