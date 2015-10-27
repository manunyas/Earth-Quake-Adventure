using UnityEngine;
using System.Collections;

public class SceneData : MonoBehaviour {
	public bool NextEnd;
	public bool RunScene;

	// Use this for initialization
	void Start () {
		NextEnd = false;
		RunScene = false;
	}
	
	// Update is called once per frame
	void Update () {
		checkNext ();
		run ();
	}

	void checkNext()
	{
		if (NextEnd == true) {
			RunScene = true;
			NextEnd = false;
		}
	}

	void run()
	{
		if (RunScene == true) {
			Time.timeScale = 1;
		}
		if (RunScene == false) {
			Time.timeScale = 0;
		}
	}
}
