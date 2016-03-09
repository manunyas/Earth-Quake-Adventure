using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenPanel : MonoBehaviour {
	public Canvas infoCanvas;

	// Use this for initialization
	void Start () {
		infoCanvas = infoCanvas.GetComponent<Canvas> ();
		infoCanvas.enabled = false;
	
	}
	
	public void PressOpen()
	{
		infoCanvas.enabled = true;
	}

	public void PressClose()
	{
		infoCanvas.enabled = false;
	}
}
