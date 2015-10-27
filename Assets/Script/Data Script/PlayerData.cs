using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
	public bool isTimeOut = false;
	public float maxHP;
	public float maxStage;
	public float damage;
	public float currentHP;
	public float currentStage;
	public int CoinCount,PointsCount;

	// Use this for initialization
	void Start () {
		CoinCount = 0;
		PointsCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		StopTime ();
		currentStage += Time.deltaTime;
	}

	void StopTime () {
		if (currentStage > maxStage) {
			isTimeOut = true;
			Time.timeScale = 0;
		} if (currentHP < 0) {
			isTimeOut = true;
			Time.timeScale = 0;
		}
	}
}
