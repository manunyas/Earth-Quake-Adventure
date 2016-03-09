using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameTap : MonoBehaviour {
	public float TapValue,currentValue;
	public Canvas QuestionCanvas,DieFailCanvas;

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxStage;
		QuestionCanvas = QuestionCanvas.GetComponent<Canvas> ();
		DieFailCanvas = DieFailCanvas.GetComponent<Canvas> ();
		QuestionCanvas.enabled = false;
		DieFailCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		CheckComplete ();
	}

	void CheckComplete()
	{
		if (currentValue > DataCenter.instance.playerDataObject.maxStage && DataCenter.instance.playerDataObject.currentStage < currentValue) {
			QuestionCanvas.enabled = true;
			DataCenter.instance.playerDataObject.PointCount = 1000;
			DataCenter.instance.playerDataObject.n = 200;
		}else if (currentValue < DataCenter.instance.playerDataObject.maxStage && DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage) {
			DieFailCanvas.enabled = true;
		}
	}

	public void PressTap()
	{
		GetComponent<Slider> ().value += TapValue;
		currentValue += TapValue;
	}

	public void PressHome()
	{
		Application.LoadLevel (1);
		DataCenter.instance.sceneDataObject.RunScene = true;
	}

}
