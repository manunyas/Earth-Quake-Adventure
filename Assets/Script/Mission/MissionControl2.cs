using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionControl2 : MonoBehaviour {
	public Canvas questionCanvas,ResultCanvas,DieCanvas,RestgCanvas,NextstgCanvas;
	public Text rightTxt,wrongTxt,archiveText;
	public int pressCount,rightAnswerNo,currentScene,nextScene,bonusPoint,point,currentPoint,finalPoint;

	// Use this for initialization
	void Start () {
		questionCanvas = questionCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		DieCanvas = DieCanvas.GetComponent<Canvas> ();
		RestgCanvas = RestgCanvas.GetComponent<Canvas> ();
		NextstgCanvas = NextstgCanvas.GetComponent<Canvas> ();

		rightTxt = rightTxt.GetComponent<Text> ();
		wrongTxt = wrongTxt.GetComponent<Text> ();
		archiveText = archiveText.GetComponent<Text> ();

		questionCanvas.enabled = false;
		ResultCanvas.enabled = false;
		DieCanvas.enabled = false;
		RestgCanvas.enabled = false;
		NextstgCanvas.enabled = false;
	
	}
	// Update is called once per frame
	void Update () 
	{
		currentPoint = DataCenter.instance.playerDataObject.PointCount;

		Goal ();
		mainquestCheck ();

	}

	void Goal()
	{
		if (DataCenter.instance.sceneDataObject.StartStage == true)
		{
			questionCanvas.enabled = true;
		}
	}

	void mainquestCheck()
	{
		if(pressCount == rightAnswerNo){
			//Calculate last score
			finalPoint = currentPoint * bonusPoint;
			DataCenter.instance.playerDataObject.bonusPointCount = finalPoint;
			DataCenter.instance.playerDataObject.n = 100;
			ResultCanvas.enabled = true;
			rightTxt.enabled = true;
			wrongTxt.enabled = false;
			questionCanvas.enabled = false;
			NextstgCanvas.enabled = true;
		}else if(DataCenter.instance.playerDataObject.EndStage == true && pressCount < 6)
		{
			ResultCanvas.enabled = true;
			wrongTxt.enabled = true;
			rightTxt.enabled = false;
			RestgCanvas.enabled = true;
			NextstgCanvas.enabled = false;
			archiveText.enabled = true;
		}
	}

	public void rightPress()
	{
		pressCount += 1;
		DataCenter.instance.playerDataObject.PointCount += point;
<<<<<<< HEAD
		archiveText.enabled = false;
=======
		DataCenter.instance.playerDataObject.exp += point;
>>>>>>> Thonyatorn/master
	}

	public void wrongPress()
	{
		ResultCanvas.enabled = true;
		rightTxt.enabled = false;
		wrongTxt.enabled = true;
		questionCanvas.enabled = false;
		RestgCanvas.enabled = true;
	}

	public void restagePress()
	{
		DieCanvas.enabled = false;
		Application.LoadLevel (currentScene);
	}

	public void nextstagePress()
	{
		DataCenter.instance.playerDataObject.exp += finalPoint; //Add Bonus point to exp
		DataCenter.instance.Save (); //Save data before star new stage
		Application.LoadLevel (nextScene);
	}

	public void PressHome()
	{
		Application.LoadLevel (3);
	}
}
