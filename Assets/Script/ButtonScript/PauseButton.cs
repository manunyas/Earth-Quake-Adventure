using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {
	public Canvas DieAndPauseCanvas;
	public Image img1,img2;
	public Button Pause_btn;

	// Use this for initialization
	void Start () {
		DieAndPauseCanvas = DieAndPauseCanvas.GetComponent<Canvas> ();
		img1 = img1.GetComponent<Image> ();
		img2 = img2.GetComponent<Image> ();
		Pause_btn = Pause_btn.GetComponent<Button> ();

		DieAndPauseCanvas.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressPause()
	{
		DieAndPauseCanvas.enabled = true;
		DataCenter.instance.sceneDataObject.RunScene = false;
	}
}
