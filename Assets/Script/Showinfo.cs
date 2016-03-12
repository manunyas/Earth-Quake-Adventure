using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Showinfo : MonoBehaviour {

	// Use this for initialization
	public Canvas showInfoCanvas;
	void start(){
		showInfoCanvas = showInfoCanvas.GetComponent<Canvas>();
		showInfoCanvas.enabled = false;
	}  
	public void PressInfo() { 
		showInfoCanvas.enabled = true;
	} 
	public void PressCloseInfo(){ 
		showInfoCanvas.enabled = false;
	}

}
