using UnityEngine;
using System.Collections;

public class spawnCoin : MonoBehaviour {

	public GameObject coin;
	public float spawnWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnCoin ());
	}
	
	IEnumerator SpawnCoin()
	{
		yield return new WaitForSeconds(spawnWait);
		Instantiate (coin, new Vector3 (9.6f, 0.96f, -1f), Quaternion.identity);
		StartCoroutine (SpawnCoin ());
		
	}
}
