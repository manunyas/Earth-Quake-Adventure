using UnityEngine;
using System.Collections;

public class SavingTimer : MonoBehaviour {
	private float time;
	//This is prototype to set PlayerPref

	// Use this for initialization
	void Start () {
		time = PlayerPrefs.GetFloat ("Timer",0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	
	}
	void OnGUI()
	{
		GUILayout.Label (time.ToString());
	}

	void OnDestroy()
	{
		PlayerPrefs.SetFloat ("Timer",time);
		PlayerPrefs.Save ();
	}
}
