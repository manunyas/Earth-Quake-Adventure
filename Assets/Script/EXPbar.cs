using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EXPbar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxExp;
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().value = DataCenter.instance.playerDataObject.exp;
	
	}
}
