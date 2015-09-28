using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().value = DataCenter.instance.playerDataObject.maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().value = DataCenter.instance.playerDataObject.currentTime;

	}
}
