using UnityEngine;
using System.Collections;

public class spawnStone : MonoBehaviour {

	public GameObject stone;
	public float spawnWait;
	
	void Start () {
		StartCoroutine (SpawnStone ());
	}

	IEnumerator SpawnStone()
	{
		spawnWait = Random.Range (0.7f,1.5f);
		yield return new WaitForSeconds(spawnWait);
		Instantiate (stone, new Vector3 (9.6f, -2.25f, -1f), Quaternion.identity);
		StartCoroutine (SpawnStone ());

	}
}
