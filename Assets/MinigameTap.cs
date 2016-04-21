using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameTap : MonoBehaviour {
	public float TapValue,currentValue,currentStage;
	public Canvas QuestionCanvas,DieFailCanvas;
	public Text DieText,failText;

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxStage;
		GetComponent<Slider> ().value = currentValue;
		currentStage = DataCenter.instance.playerDataObject.currentStage;
		QuestionCanvas = QuestionCanvas.GetComponent<Canvas> ();
		DieFailCanvas = DieFailCanvas.GetComponent<Canvas> ();
		DieText = DieText.GetComponent<Text> ();
		failText = failText.GetComponent<Text> ();

		QuestionCanvas.enabled = false;
		DieFailCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		CheckComplete ();
		currentStage = DataCenter.instance.playerDataObject.currentStage;
	}

	void CheckComplete()
	{
		if (currentValue > DataCenter.instance.playerDataObject.maxStage && DataCenter.instance.playerDataObject.currentStage < currentValue) {
			QuestionCanvas.enabled = true;
			DataCenter.instance.playerDataObject.PointCount = 1000;
			DataCenter.instance.playerDataObject.n = 200;
		//Success then show question before end stage
		}else if (currentStage > currentValue) {
			DieFailCanvas.enabled = true;
			DieText.enabled = true;
			failText.enabled = false;
			DataCenter.instance.sceneDataObject.RunScene = false;
		//Not success and shoe die message
		}
	}

	public void PressTap()
	{
		GetComponent<Slider> ().value += TapValue;
		currentValue += TapValue;
		//add value
	}

	public void PressHome()
	{
		Application.LoadLevel (1);
		DataCenter.instance.sceneDataObject.RunScene = true;
	}

}
