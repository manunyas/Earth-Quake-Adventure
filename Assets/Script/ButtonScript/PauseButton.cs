using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {
	public Canvas PauseCanvas;
	public Button Pause_btn, home_btn, continued_btn;

	// Use this for initialization
	void Start () {
		PauseCanvas = PauseCanvas.GetComponent<Canvas> ();
		Pause_btn = Pause_btn.GetComponent<Button> ();

		//
		home_btn = home_btn.GetComponent<Button> ();
		continued_btn = continued_btn.GetComponent<Button> ();

		PauseCanvas.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PressPause()
	{
		PauseCanvas.enabled = true;
		DataCenter.instance.sceneDataObject.RunScene = false;
	}

	public void PressContinued()
	{
		DataCenter.instance.sceneDataObject.RunScene = true;
		PauseCanvas.enabled = false;
	}

	public void PressHome()
	{
		Application.LoadLevel (1);
		PauseCanvas.enabled = false;
		DataCenter.instance.sceneDataObject.RunScene = true;
	}
}
