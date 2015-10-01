using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashboardControl : MonoBehaviour {
	public Button startButton;

	// Use this for initialization
	void Start () {

		startButton = startButton.GetComponent<Button> ();
	}

	void StartPress (){

		startButton.enabled = true;

	}
	public void StartLevel ()
	{
		Application.LoadLevel (2);
	}
}
