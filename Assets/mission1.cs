using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class mission1 : MonoBehaviour {
	public Canvas questionCanvas,SuccessCanvas;
	public Button yesBtn,noBtn;
	public int missionCoin,coinCount;
	public float currentStage, maxStage;

	// Use this for initialization
	void Start () {
		questionCanvas = questionCanvas.GetComponent<Canvas> ();
		SuccessCanvas = SuccessCanvas.GetComponent<Canvas> ();
		yesBtn = yesBtn.GetComponent<Button> ();
		noBtn = noBtn.GetComponent<Button> ();

		//Dont show canvas first
		questionCanvas.enabled = false;
		SuccessCanvas.enabled = false;

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
		DataCenter.instance.playerDataObject.PointsCount = DataCenter.instance.playerDataObject.PointsCount*2;
		SuccessCanvas.enabled = true;
		questionCanvas.enabled = false;
	}
}
