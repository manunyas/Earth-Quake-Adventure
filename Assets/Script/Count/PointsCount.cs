using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsCount : MonoBehaviour {
	public string pointCount;

	// Use this for initialization
	void Start () {
		pointCount = DataCenter.instance.playerDataObject.PointsCount.ToString ();
		GetComponent<Text> ().text = pointCount;
	
	}
	
	// Update is called once per frame
	void Update () {
		pointCount = DataCenter.instance.playerDataObject.PointsCount.ToString ();
		GetComponent<Text> ().text = pointCount;
	}
}
