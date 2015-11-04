using UnityEngine;
using System.Collections;

public class SpawnObj : MonoBehaviour {
	public GameObject gameObj;
	public float spawnWait,minTime,maxTime,x,y,z;

	// Use this for initialization
	void Start () {
		StartCoroutine (spawnObj ());
	}
	
	IEnumerator spawnObj()
	{
		spawnWait = Random.Range (minTime,maxTime);
		yield return new WaitForSeconds(spawnWait);
		if (DataCenter.instance.playerDataObject.currentHP > 0 && DataCenter.instance.playerDataObject.currentStage < DataCenter.instance.playerDataObject.maxStage ) {
			Instantiate (gameObj, new Vector3 (x, y, z), Quaternion.identity);
			StartCoroutine (spawnObj ());
		}
	}
}
