using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EXPCount : MonoBehaviour {
	public string p;

	// Use this for initialization
	void Start () {
		DataCenter.instance.Load ();
		p = DataCenter.instance.playerDataObject.exp.ToString ();
		GetComponent<Text> ().text = p;
	
	}
	
	// Update is called once per frame
	void Update () {
		p = DataCenter.instance.playerDataObject.exp.ToString ();
		GetComponent<Text> ().text = p;
	
	}
}
