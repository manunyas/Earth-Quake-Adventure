using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour {
	public string coinCount;

	// Use this for initialization
	void Start () {
		coinCount = DataCenter.instance.playerDataObject.CoinCount.ToString();
		GetComponent<Text> ().text = coinCount;
	
	}
	
	// Update is called once per frame
	void Update () {
		coinCount = DataCenter.instance.playerDataObject.CoinCount.ToString();
		GetComponent<Text> ().text = coinCount;
	}
}
