using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BonusPointCount : MonoBehaviour {
	public string bonusPointTxt;

	// Use this for initialization
	void Start () {
		bonusPointTxt = DataCenter.instance.playerDataObject.bonusPointCount.ToString ("n0");
		GetComponent<Text> ().text = bonusPointTxt;
	
	}
	
	// Update is called once per frame
	void Update () {
		bonusPointTxt = DataCenter.instance.playerDataObject.bonusPointCount.ToString ("n0");
		GetComponent<Text> ().text = bonusPointTxt;
	}
}
