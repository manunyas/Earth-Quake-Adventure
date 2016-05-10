using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageValue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxStage;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxStage; //Reset PlayerData
		GetComponent<Slider> ().value = DataCenter.instance.playerDataObject.currentStage;
	}
}
