using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
	public bool isTimeOut = false;
	public float maxHP;
	public float damage;
	public float currentHP;
	public int CoinCount;

	// Use this for initialization
	void Start () {
		CoinCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		StopTime ();
		currentHP -= Time.deltaTime;
	}

	void StopTime () {
		if (currentHP < 0){
			isTimeOut = true;
			Time.timeScale = 0;
		}
	}
}
