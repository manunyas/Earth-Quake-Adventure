using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsCount : MonoBehaviour {
	public string p;

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = p;
	}
	
	// Update is called once per frame
	void Update () {
		p = DataCenter.instance.playerDataObject.PointCountFloat.ToString ("n0");
		GetComponent<Text> ().text = p;
	}
}
