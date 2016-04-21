using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpecialCount : MonoBehaviour {
	public string special_Count;

	// Use this for initialization
	void Start () {
		special_Count = DataCenter.instance.playerDataObject.specialCount.ToString();
		GetComponent<Text> ().text = special_Count;
	
	}
	
	// Update is called once per frame
	void Update () {
		special_Count = DataCenter.instance.playerDataObject.specialCount.ToString();
		GetComponent<Text> ().text = special_Count;
	}
}
