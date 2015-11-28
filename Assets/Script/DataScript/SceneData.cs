using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneData : MonoBehaviour {
	public bool NextEnd;
	public bool RunScene;
	public bool StartStage;

	// Use this for initialization
	void Start () {
		NextEnd = false;
		RunScene = true;
		StartStage = false;
	}
	
	// Update is called once per frame
	void Update () {
		RunTheScene ();
		changeStartStage ();
	}

	//use time scale it stop all things in scene
	void RunTheScene()
	{
		if (RunScene == true) {
			Time.timeScale = 1;
		}else if (RunScene == false) {
			Time.timeScale = 0;
		}
	}

	void changeStartStage()
	{
		if (NextEnd == true) {
			StartStage = true;
		}else if (NextEnd == false) {
			StartStage = false;
		}
	}
}
