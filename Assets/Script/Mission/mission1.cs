using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mission1 : MonoBehaviour {
	public Canvas questionCanvas,ResultCanvas,missionCompleteCanvas,DieCanvas;
	public Button yesBtn,noBtn,restageBtn,homeBtn;
	public Text SuccessTxt, FailTxt, ArchivementTxt, DieTxt, missionFailTxt;
	public int missionCoin,coinCount;
	public float currentStage, maxStage, currentHP, maxHP;
	public bool mission_success = false;

	// Use this for initialization
	void Start () {
		questionCanvas = questionCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		missionCompleteCanvas = missionCompleteCanvas.GetComponent<Canvas> ();
		DieCanvas = DieCanvas.GetComponent<Canvas> ();

		yesBtn = yesBtn.GetComponent<Button> ();
		noBtn = noBtn.GetComponent<Button> ();
		restageBtn = restageBtn.GetComponent<Button> ();
		homeBtn = homeBtn.GetComponent<Button> ();

		SuccessTxt = SuccessTxt.GetComponent<Text> ();
		FailTxt = FailTxt.GetComponent<Text> ();
		DieTxt = DieTxt.GetComponent<Text> ();
		missionFailTxt = missionFailTxt.GetComponent<Text> ();
		ArchivementTxt = ArchivementTxt.GetComponent<Text> ();

		//Dont show canvas first
		questionCanvas.enabled = false;
		ResultCanvas.enabled = false;
		DieCanvas.enabled = false;
		missionCompleteCanvas.enabled = false;

		//Get fixed value from Data Center
		maxStage = DataCenter.instance.playerDataObject.maxStage;
		maxHP = DataCenter.instance.playerDataObject.maxHP;
	}

	void Update () {
		//Get value from Data Center realtime
		currentStage = DataCenter.instance.playerDataObject.currentStage;
		currentHP = DataCenter.instance.playerDataObject.currentHP;
		coinCount = DataCenter.instance.playerDataObject.CoinCount;

		missionSuccessCheck ();
		Goal ();
		showToast ();
	}
	
	void Goal()
	{
		if (mission_success == true && currentStage > maxStage && currentHP > 0 ) {
			questionCanvas.enabled = true;
		}else if (currentHP < 0) {
			DieCanvas.enabled = true;
			DieTxt.enabled = true;
			missionFailTxt.enabled = false;
		}else if (mission_success == false && currentStage > maxStage && currentHP > 0) {
			DieCanvas.enabled = true;
			DieTxt.enabled = false;
			missionFailTxt.enabled = true;
		}
	}
	//mission success
	void missionSuccessCheck()
	{
		if(coinCount > 49){
			mission_success = true;
		}else {
			mission_success = false;
		}
	}
	//Show toast 'mission complete'
	void showToast()
	{
		if (mission_success == true && coinCount < 52 ) {
			missionCompleteCanvas.enabled = true;
			}else if (coinCount > 52) {
			missionCompleteCanvas.enabled = false;
		}
	}

	public void yesPress()
	{
		DataCenter.instance.playerDataObject.PointCount = DataCenter.instance.playerDataObject.PointCount*2;
		DataCenter.instance.playerDataObject.n = 500;
		ResultCanvas.enabled = true;
		SuccessTxt.enabled = true;
		ArchivementTxt.enabled = true;
		FailTxt.enabled = false;
		questionCanvas.enabled = false;
	}

	public void noPress()
	{
		ResultCanvas.enabled = true;
		SuccessTxt.enabled = false;
		ArchivementTxt.enabled = false;
		FailTxt.enabled = true;
		questionCanvas.enabled = false;
	}

	public void restagePress()
	{
		DieCanvas.enabled = false;
		Application.LoadLevel (4);
	}

	public void nextstagePress()
	{
		Application.LoadLevel (5);
	}


}
