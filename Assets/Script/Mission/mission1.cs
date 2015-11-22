using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mission1 : MonoBehaviour {
	public Canvas questionCanvas,ResultCanvas;
	public Button yesBtn,noBtn;
	public Text SuccessTxt, FailTxt, ArchivementTxt;
	public int missionCoin,coinCount;
	public float currentStage, maxStage;

	// Use this for initialization
	void Start () {
		questionCanvas = questionCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		yesBtn = yesBtn.GetComponent<Button> ();
		noBtn = noBtn.GetComponent<Button> ();
		SuccessTxt = SuccessTxt.GetComponent<Text> ();
		FailTxt = FailTxt.GetComponent<Text> ();
		ArchivementTxt = ArchivementTxt.GetComponent<Text> ();

		//Dont show canvas first
		questionCanvas.enabled = false;
		ResultCanvas.enabled = false;

		//Get value from Data Center
		maxStage = DataCenter.instance.playerDataObject.maxStage;

	
	}
	// Update is called once per frame
	void Update () {
		//Get value from Data Center realtime
		currentStage = DataCenter.instance.playerDataObject.currentStage;
		coinCount = DataCenter.instance.playerDataObject.CoinCount;
		Goal ();
	}
	void Goal()
	{
		if (coinCount > missionCoin && currentStage > maxStage) {
			questionCanvas.enabled = true;
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
}
