using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
	public bool Hit = false;
	public float maxHP,maxStage;
	public float damage;
	public float currentHP,currentStage,PointCountFloat;
	public int n,CoinCount,PointCount,MissionCoin;

	// Use this for initialization
	void Start () {
		CoinCount = 0;
		PointCount = 0;
		PointCountFloat = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CountStage ();
		CountPoint ();
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

	void CountPoint()
	{
		if (PointCountFloat != PointCount && PointCountFloat <= PointCount) {
			PointCountFloat += Time.deltaTime*n;
		}

	}
	

}
