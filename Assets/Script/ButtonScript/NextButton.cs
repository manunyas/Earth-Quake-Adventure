using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {
	public Button nextBtn;

	// Use this for initialization
	void Start () {
		nextBtn = nextBtn.GetComponent<Button> ();

	}
	
	public void PressNextBtn()
	{
		nextBtn.enabled = true;
		DataCenter.instance.sceneDataObject.NextEnd = true;
		gameObject.SetActive (false);
	}
}
