using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DashboardControl : MonoBehaviour {
	public Button startButton;
	public Button backButton;

	// Use this for initialization
	void Start () {

		startButton = startButton.GetComponent<Button> ();
		backButton = backButton.GetComponent<Button> ();
	}

	void StartPress (){

		startButton.enabled = true;

	}
	public void StartLevel ()
	{
		Application.LoadLevel (2);
	}
	public void BackLevel ()
	{
		Application.LoadLevel (0);
	}
}
