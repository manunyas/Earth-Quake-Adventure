using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {
	public Canvas scene1,scene2,scene3,scene4,scene5,scene6,scene7,missionCanvas;
	public Button nextButton,previousButton;
	public int countNextpress,countNextToEnd,countToStart;
	public float maxStage,currentHP;
	public bool endStage = false;

	// Use this for initialization
	void Start () {
		//==========Load Data from playerInfo==========
		DataCenter.instance.Load();

		//===========Reset data from last EP===========
		//Reset SceneData
		DataCenter.instance.sceneDataObject.NextEnd = false;
		DataCenter.instance.sceneDataObject.StartStage = false;

		//Reset PlayerData
		DataCenter.instance.playerDataObject.currentStage = 0;
		DataCenter.instance.playerDataObject.PointCount = 0;
		DataCenter.instance.playerDataObject.PointCountFloat = 0;
		DataCenter.instance.playerDataObject.CoinCount = 0;
		DataCenter.instance.playerDataObject.specialCount = 0;
		DataCenter.instance.playerDataObject.bonusPointCount = 0;
		DataCenter.instance.playerDataObject.currentHP = DataCenter.instance.playerDataObject.maxHP;
		DataCenter.instance.playerDataObject.maxStage = maxStage;
		DataCenter.instance.playerDataObject.EndStage = false;

		//===========Check maxHP by Level for setting PlayerData============
		/*currentEXP = DataCenter.instance.playerDataObject.exp;
		if (currentEXP < 600) {
			DataCenter.instance.playerDataObject.maxHP = 70;
		}else if (currentEXP < 1138) {
			DataCenter.instance.playerDataObject.maxHP = 72;
		}else if (currentEXP < 2157) {
			DataCenter.instance.playerDataObject.maxHP = 74;
		}else if (currentEXP < 4089) {
			DataCenter.instance.playerDataObject.maxHP = 78;
		}*/

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
		DataCenter.instance.playerDataObject.currentHP = DataCenter.instance.playerDataObject.maxHP;
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
