using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Story2 : MonoBehaviour {
	public Canvas scene1,scene2,scene3,scene4,scene5,missionCanvas;
	public Button nextButton;
	public int countNextpress;

	// Use this for initialization
	void Start () {
		scene1 = scene1.GetComponent<Canvas> ();
		scene2 = scene2.GetComponent<Canvas> ();
		scene3 = scene3.GetComponent<Canvas> ();
		scene4 = scene4.GetComponent<Canvas> ();
		scene5 = scene5.GetComponent<Canvas> ();
		missionCanvas = missionCanvas.GetComponent<Canvas> ();
		nextButton = nextButton.GetComponent<Button> ();

		scene2.enabled = false;
		scene3.enabled = false;
		scene4.enabled = false;
		scene5.enabled = false;
		missionCanvas.enabled = false;

	}

	void Update()
	{
		countNextBtn ();
	}

	public void PressNextBtn()
	{
		countNextpress += 1;
	}

	void countNextBtn()
	{
		if (countNextpress == 6) {
			DataCenter.instance.sceneDataObject.NextEnd = true;
			gameObject.SetActive (false);
		}else if (countNextpress == 1) {
			scene2.enabled = true;
		}else if (countNextpress == 2) {
			scene3.enabled = true;
		}else if (countNextpress == 3) {
			scene4.enabled = true;
		}else if (countNextpress == 4) {
			scene5.enabled = true;
		}else if (countNextpress == 5) {
			missionCanvas.enabled = true;
		}
	}
}
