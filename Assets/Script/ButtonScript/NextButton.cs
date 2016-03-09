using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {
	public Canvas scene1,scene2,scene3,scene4,scene5,scene6,scene7,missionCanvas;
	public Button nextButton,previousButton;
	public int countNextpress,countNextToEnd,countToStart;

	// Use this for initialization
	void Start () {
		scene1 = scene1.GetComponent<Canvas> ();
		scene2 = scene2.GetComponent<Canvas> ();
		scene3 = scene3.GetComponent<Canvas> ();
		scene4 = scene4.GetComponent<Canvas> ();
		scene5 = scene5.GetComponent<Canvas> ();
		scene6 = scene6.GetComponent<Canvas> ();
		scene7 = scene7.GetComponent<Canvas> ();
		missionCanvas = missionCanvas.GetComponent<Canvas> ();
		nextButton = nextButton.GetComponent<Button> ();
		previousButton = previousButton.GetComponent<Button> ();

		scene2.enabled = false;
		scene3.enabled = false;
		scene4.enabled = false;
		scene5.enabled = false;
		scene6.enabled = false;
		scene7.enabled = false;
		missionCanvas.enabled = false;
		previousButton.enabled = false;

	}

	void Update()
	{
		countNextBtn ();
		showPreviousBtn ();
	}
	
	public void PressNextBtn()
	{
		countNextpress += 1;
	}

	public void PressPreviousBtn()
	{
		countNextpress -= 1;
	}
	void showPreviousBtn()
	{
		if (countNextpress < countToStart) {
			previousButton.enabled = false;
		} else {
			previousButton.enabled = true;
		}
	}
	void countNextBtn()
	{
		if (countNextpress == countNextToEnd) {
			DataCenter.instance.sceneDataObject.NextEnd = true; //Important to Start the game
			gameObject.SetActive (false);
		}else if (countNextpress == 0) {
			scene2.enabled = false;
			scene3.enabled = false;
			scene4.enabled = false;
			scene5.enabled = false;
			scene6.enabled = false;
			scene7.enabled = false;
		}else if (countNextpress == 1) {
			scene2.enabled = true;
			scene3.enabled = false;
			scene4.enabled = false;
			scene5.enabled = false;
			scene6.enabled = false;
			scene7.enabled = false;
		}else if (countNextpress == 2) {
			scene2.enabled = false;
			scene3.enabled = true;
			scene4.enabled = false;
			scene5.enabled = false;
			scene6.enabled = false;
			scene7.enabled = false;
		}else if (countNextpress == 3) {
			scene2.enabled = false;
			scene3.enabled = false;
			scene4.enabled = true;
			scene5.enabled = false;
			scene6.enabled = false;
			scene7.enabled = false;
		}else if (countNextpress == 4) {
			scene2.enabled = false;
			scene3.enabled = false;
			scene4.enabled = false;
			scene5.enabled = true;
			scene6.enabled = false;
			scene7.enabled = false;
		}else if (countNextpress == 5) {
			scene2.enabled = false;
			scene3.enabled = false;
			scene4.enabled = false;
			scene5.enabled = false;
			scene6.enabled = true;
			scene7.enabled = false;
		}else if (countNextpress == 6) {
			scene2.enabled = false;
			scene3.enabled = false;
			scene4.enabled = false;
			scene5.enabled = false;
			scene6.enabled = false;
			scene7.enabled = true;
		}else if (countNextpress == 7) {
			scene2.enabled = false;
			scene3.enabled = false;
			scene4.enabled = false;
			scene5.enabled = false;
			scene6.enabled = false;
			scene7.enabled = false;
			previousButton.gameObject.SetActive (false);
			missionCanvas.enabled = true;
		}
	}
}
