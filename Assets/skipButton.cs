using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class skipButton : MonoBehaviour {
	public Canvas QuestionCanvas, ResultCanvas, nextBtnCanvas, reBtncanvas;
	public int currentStage, nextStage,AnswerNumber,rightCount,rightNumber,pressCount;

	public Text righttxt, wrongtxt, bonustxt, achivementTxt;
	public bool Readed;

	// Use this for initialization
	void Start () {
		QuestionCanvas = QuestionCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		nextBtnCanvas = nextBtnCanvas.GetComponent<Canvas> ();
		reBtncanvas = reBtncanvas.GetComponent<Canvas> ();

		righttxt = righttxt.GetComponent<Text> ();
		wrongtxt = wrongtxt.GetComponent <Text> ();
		bonustxt = bonustxt.GetComponent<Text> ();
		achivementTxt = achivementTxt.GetComponent<Text> ();

		QuestionCanvas.enabled = false;
		ResultCanvas.enabled = false;
		nextBtnCanvas.enabled = false;
		reBtncanvas.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		showCanvas ();
		showResult ();
	}

	void showCanvas()
	{
		if (Readed == true) {
			QuestionCanvas.enabled = true;
		}
	}

	void showResult()
	{
		if (pressCount == AnswerNumber) {
			//if player press answer equal numbet that player must answer then into this if
			if (rightCount == rightNumber) {
				//if player click right button equal right answer
				ResultCanvas.enabled = true;
				righttxt.enabled = true;
				wrongtxt.enabled = false;
				bonustxt.enabled = true;
				achivementTxt.enabled = true;
				nextBtnCanvas.enabled = true;
				reBtncanvas.enabled = false;
				DataCenter.instance.playerDataObject.PointCountFloat = 10000;
				DataCenter.instance.playerDataObject.bonusPointCount = 5000;
			}else if (rightCount != rightNumber){
				ResultCanvas.enabled = true;
				righttxt.enabled = false;
				wrongtxt.enabled = true;
				bonustxt.enabled = false;
				achivementTxt.enabled = false;
				nextBtnCanvas.enabled = false;
				reBtncanvas.enabled = true;
			}


		}
	}

	public void pressright()
	{
		rightCount += 1;
		pressCount += 1;
	}

	public void pressWrong()
	{
		pressCount += 1;
	}

	public void pressSkip()
	{
		DataCenter.instance.playerDataObject.currentStage = DataCenter.instance.playerDataObject.maxStage;
		Readed = true;
	}

	public void pressHome()
	{
		Application.LoadLevel (1);
	}

	public void pressRestg()
	{
		Application.LoadLevel (currentStage);
	}

	public void pressNextstg()
	{
		Application.LoadLevel (nextStage);
	}
}
