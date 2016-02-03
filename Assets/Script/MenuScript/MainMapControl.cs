using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMapControl : MonoBehaviour {
	public Button forestButton;
	public Button backButton;

	// Use this for initialization
	void Start () {
		forestButton = forestButton.GetComponent<Button> ();
		backButton = backButton.GetComponent<Button> ();
	
	}

	// Update is called once per frame
	void forestPress(){
		forestButton.enabled = true;
		backButton.enabled = false;
	}

	void backPress(){
		forestButton.enabled = false;
		backButton.enabled = true;
	}

	public void StartLevel(){
		Application.LoadLevel (4);
	}
	public void back(){
		Application.LoadLevel (1);
	}

}
