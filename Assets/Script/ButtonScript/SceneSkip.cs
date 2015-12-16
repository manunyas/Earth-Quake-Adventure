using UnityEngine;
using System.Collections;

public class SceneSkip : MonoBehaviour {
	public int sceneLevel;
	
	void Start () {
	}

	void Update()
	{
	}

	public void PressSceneSkip()
	{
		Application.LoadLevel (sceneLevel);
	}

}
