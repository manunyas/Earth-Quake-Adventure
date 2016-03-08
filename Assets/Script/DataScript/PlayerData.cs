using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {
	public bool Hit = false, EndStage = false;
	public float maxHP,maxStage;
	public float damage;
	public float currentHP,currentStage,PointCountFloat;
	public int n,CoinCount,PointCount;

	// Use this for initialization
	void Start () {
		CoinCount = 0; //Main Object that need to count and show
		PointCount = 0;
		PointCountFloat = 0;
	}
	
	// Update is called once per frame
	void Update () {
		CountStage ();
		CountPoint ();
		EndStageCheck ();
	}

	void CountStage ()
	{
		if (DataCenter.instance.sceneDataObject.StartStage == true) {
			if (currentHP > 0) {
				currentStage += Time.deltaTime;
			}
			if (currentHP < 0) {
				currentStage += 0;
			}
		}

	}

	void CountPoint()
	{
		if (PointCountFloat != PointCount && PointCountFloat <= PointCount) {
			PointCountFloat += Time.deltaTime*n;
		}

	}

	void EndStageCheck()
	{
		//End way
		if (DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage) {
			EndStage = true;
		}
		//Out of HP
		else if (DataCenter.instance.playerDataObject.currentHP < 0) {
			EndStage = true;
		}
	}
	

}
