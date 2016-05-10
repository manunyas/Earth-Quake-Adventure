using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameTap : MonoBehaviour {
	public float TapValue,playerValue,enermyValue,maxValue,point;
	public Canvas QuestionCanvas,DieFailCanvas,ResultCanvas,RestageBtnCanvas,NextBtnCanvas;
	public Text DieText,rightText,wrongText,achivementText;
	public bool Die = false, Win = false;
	public int nextScene,currentScene,RightAnswer,AnswerCount,bonusPoint;

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().value = playerValue; 

		QuestionCanvas = QuestionCanvas.GetComponent<Canvas> ();
		DieFailCanvas = DieFailCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		RestageBtnCanvas = RestageBtnCanvas.GetComponent<Canvas> ();
		NextBtnCanvas = NextBtnCanvas.GetComponent<Canvas> ();

		DieText = DieText.GetComponent<Text> ();
		rightText = rightText.GetComponent<Text> ();
		wrongText = wrongText.GetComponent<Text> ();
		achivementText = achivementText.GetComponent<Text> ();

		QuestionCanvas.enabled = false;
		DieFailCanvas.enabled = false;
		RestageBtnCanvas.enabled = false;
		NextBtnCanvas.enabled = false;
		ResultCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().value = playerValue; 
		maxValue = DataCenter.instance.playerDataObject.maxStage;
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxStage;
		enermyValue = DataCenter.instance.playerDataObject.currentStage;

		PlayerLose ();
		PlayerWin ();
		WinStage ();

		DataCenter.instance.sceneDataObject.RunScene = true;
	}

	void PlayerLose()
	{
		//Player lose enermy and need to restage
		if (enermyValue > playerValue) {
			DieFailCanvas.enabled = true;
			DieText.enabled = true;
			DataCenter.instance.sceneDataObject.RunScene = false;
			Time.timeScale = 0;
			Die = true; //for check
		}
	}

	void PlayerWin()
	{
		//Player win enermy and need to answer question
		if (playerValue > enermyValue && playerValue > DataCenter.instance.playerDataObject.maxStage) {
			DataCenter.instance.playerDataObject.currentStage = 0;
			QuestionCanvas.enabled = true; //Show question to answer
			Win = true; //for check
		}
	}

	void WinStage()
	{
		if (AnswerCount == RightAnswer) {
			ResultCanvas.enabled = true;
			rightText.enabled = true;
			wrongText.enabled = false;
			RestageBtnCanvas.enabled = false;
			NextBtnCanvas.enabled = true;
			achivementText.enabled = true;

			DataCenter.instance.playerDataObject.PointCountFloat = point;
			DataCenter.instance.playerDataObject.bonusPointCount = bonusPoint;
			DataCenter.instance.playerDataObject.n = 200; //Setting n to count number
		}
	}
		
	public void PressTap()
	{
		GetComponent<Slider> ().value += TapValue;
		playerValue += TapValue;
	}

	public void PressRestag()
	{
		Application.LoadLevel (currentScene);
	}

	public void PressHome()
	{
		/*For reset Data File only
		DataCenter.instance.playerDataObject.exp = 0;
		DataCenter.instance.Save ();
		*/
		Application.LoadLevel (1);
		DataCenter.instance.sceneDataObject.RunScene = true;
	}

	public void PressNextBTN()
	{
		DataCenter.instance.playerDataObject.exp += point+(float)bonusPoint;
		DataCenter.instance.Save ();
		Application.LoadLevel (nextScene);
		
	}

	public void PressRight()
	{
		AnswerCount += 1;
	}

	public void PressWrong()
	{
		ResultCanvas.enabled = true;
		rightText.enabled = false;
		wrongText.enabled = true;
		RestageBtnCanvas.enabled = true;
		NextBtnCanvas.enabled = false;
		achivementText.enabled = false;
	}


}
