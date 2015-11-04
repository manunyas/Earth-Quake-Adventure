using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
	public bool Hit = false;
	public float maxHP;
	public float maxStage;
	public float damage;
	public float currentHP;
	public float currentStage;
	public int CoinCount,PointsCount,MissionCoin;

	// Use this for initialization
	void Start () {
		CoinCount = 0;
		PointsCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CountStage ();
	}

	void CountStage ()
	{
		if (currentHP > 0) {
			currentStage += Time.deltaTime;
		}
		if (currentHP < 0) {
			currentStage += 0;
		}
	}
	

}
