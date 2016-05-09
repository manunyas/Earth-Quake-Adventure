using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {


	int score = 10;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Level2", 1);
		PlayerPrefs.SetInt ("Level1_score" , score);
		StartCoroutine (Time ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Time()
	{
		yield return new WaitForSeconds (2f);
		Application.LoadLevel (32); ///number scene
	}
}
