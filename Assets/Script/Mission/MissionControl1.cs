using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MissionControl1 : MonoBehaviour {
	public Canvas questionCanvas,ResultCanvas,DieCanvas,RestgCanvas,NextstgCanvas,toastCanvas;
	public Text FailTxt, DieTxt,rightTxt,wrongTxt;
	public bool sidequest_success = false;
	public int sidequestCoins,pressCount,rightAnswerNo,currentScene,nextScene,bonusPoint;
	public float toastLifeTime;

	// Use this for initialization
	void Start () 
	{
		questionCanvas = questionCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		toastCanvas = toastCanvas.GetComponent<Canvas> (); 
		DieCanvas = DieCanvas.GetComponent<Canvas> ();
		RestgCanvas = RestgCanvas.GetComponent<Canvas> ();
		NextstgCanvas = NextstgCanvas.GetComponent<Canvas> ();

		FailTxt = FailTxt.GetComponent<Text> ();
		DieTxt = DieTxt.GetComponent<Text> ();
		rightTxt = rightTxt.GetComponent<Text> ();
		wrongTxt = wrongTxt.GetComponent<Text> ();

		questionCanvas.enabled = false;
		ResultCanvas.enabled = false;
		toastCanvas.enabled = false;
		DieCanvas.enabled = false;
		RestgCanvas.enabled = false;
		NextstgCanvas.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Goal ();
		sidequestCheck ();
		mainquestCheck ();
		showToast ();

	}

	void Goal()
	{
		if (DataCenter.instance.playerDataObject.currentHP < 0) {
			DieCanvas.enabled = true;
			FailTxt.enabled = false;
			DieTxt.enabled = true;
			//Die situation
		}else if(sidequest_success == true && DataCenter.instance.playerDataObject.currentHP > 0 && DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage){
			questionCanvas.enabled = true;
			//Success all situation before question		
		}else if(sidequest_success == true && DataCenter.instance.playerDataObject.currentHP < 0){
			DieCanvas.enabled = true;
			FailTxt.enabled = true;
			DieTxt.enabled = false;
			//Success sidequest but die situation
		}else if(sidequest_success == false && DataCenter.instance.playerDataObject.currentHP > 0 && DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage){
			DieCanvas.enabled = true;
			FailTxt.enabled = true;
			DieTxt.enabled = false;
			//Not success sidequest but complete stage
		}
	}

	void mainquestCheck()
	{
		if(pressCount == rightAnswerNo){
			DataCenter.instance.playerDataObject.PointCount = DataCenter.instance.playerDataObject.PointCount * bonusPoint;
			DataCenter.instance.playerDataObject.n = 500;
			ResultCanvas.enabled = true;
			rightTxt.enabled = true;
			wrongTxt.enabled = false;
			questionCanvas.enabled = false;
			NextstgCanvas.enabled = true;
		}
	}

	public void rightPress()
	{
		pressCount += 1;
	}

	public void wrongPress()
	{
		ResultCanvas.enabled = true;
		rightTxt.enabled = false;
		wrongTxt.enabled = true;
		questionCanvas.enabled = false;
		RestgCanvas.enabled = true;
	}


	void sidequestCheck()
	{
		if(DataCenter.instance.playerDataObject.CoinCount > sidequestCoins)
		{
			sidequest_success = true;
		}else {
			sidequest_success = false;
		}
	}

	//Show toast 'mission complete'
	void showToast()
	{
		if (sidequest_success == true) 
		{
			toastCanvas.enabled = true;
			toastLifeTime -= Time.deltaTime;
			if (toastLifeTime < 0) 
			{
				toastCanvas.enabled = false;
			}
		}
	}
	
	public void restagePress()
	{
		DieCanvas.enabled = false;
		Application.LoadLevel (currentScene);
	}

	public void nextstagePress()
	{
		Application.LoadLevel (nextScene);
	}
}
