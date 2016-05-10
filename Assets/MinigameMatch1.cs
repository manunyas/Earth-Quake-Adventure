using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MinigameMatch1 : MonoBehaviour {
	public Canvas MinigameCanvas,ResultCanvas,RestgCanvas,NextstgCanvas;
	public int CurrentStage,NextStage,finalPoint,numberKeep,answerKeep;
	public Button btn1,btn2,btn3,ans1,ans2,ans3;
	public Text rightTxt, wrongTxt;
	public bool a, b, c;

	// Use this for initialization
	void Start () 
	{
		MinigameCanvas = MinigameCanvas.GetComponent<Canvas> ();
		ResultCanvas = ResultCanvas.GetComponent<Canvas> ();
		RestgCanvas = RestgCanvas.GetComponent<Canvas> ();
		NextstgCanvas = NextstgCanvas.GetComponent<Canvas> ();

		btn1 = btn1.GetComponent<Button> ();
		btn2 = btn2.GetComponent<Button> ();
		btn3 = btn3.GetComponent<Button> ();

		ans1 = ans1.GetComponent<Button> ();
		ans2 = ans2.GetComponent<Button> ();
		ans3 = ans3.GetComponent<Button> ();

		rightTxt = rightTxt.GetComponent<Text> ();
		wrongTxt = wrongTxt.GetComponent<Text> ();

		ResultCanvas.enabled = false;
		RestgCanvas.enabled = false;
		NextstgCanvas.enabled = false;

	
	}
	
	// Update is called once per frame
	void Update () {
		checkMatch ();
		Goal ();
	}

	void checkMatch()
	{

		if (numberKeep == 1 && answerKeep == 1) {
			btn1.image.color = Color.green;
			ans1.image.color = Color.green;
			a = true;
		} else if (numberKeep == 2 && answerKeep == 2) {
			btn2.image.color = Color.green;
			ans2.image.color = Color.green;
			b = true;
		} else if (numberKeep == 3 && answerKeep == 3) {
			btn3.image.color = Color.green;
			ans3.image.color = Color.green;
			c = true;
		}

	}

	void Goal()
	{
		if(a == true && b == true && c == true){
			//Calculate last score
			DataCenter.instance.playerDataObject.PointCount = finalPoint;
			DataCenter.instance.playerDataObject.n = 300;
			ResultCanvas.enabled = true;
			rightTxt.enabled = true;
			wrongTxt.enabled = false;
			MinigameCanvas.enabled = false;
			NextstgCanvas.enabled = true;
		}else if(DataCenter.instance.playerDataObject.EndStage == true)
		{
			ResultCanvas.enabled = true;
			wrongTxt.enabled = true;
			rightTxt.enabled = false;
			RestgCanvas.enabled = true;
			NextstgCanvas.enabled = false;
		}
	}


	public void press1()
	{
		numberKeep = 1;
		btn1.image.color = Color.gray;
		//ibtn1.gameObject.SetActive (false); *for use erase button*
	}
	public void press2()
	{
		numberKeep = 2;
		btn2.image.color = Color.gray;
	}
	public void press3()
	{
		numberKeep = 3;
		btn3.image.color = Color.gray;
	}
	public void pressA()
	{
		answerKeep = 1;
	}
	public void pressB()
	{
		answerKeep = 2;
	}
	public void pressC()
	{
		answerKeep = 3;
	}

	public void restagePress()
	{
		ResultCanvas.enabled = false;
		Application.LoadLevel (CurrentStage);
	}

	public void nextstagePress()
	{
		DataCenter.instance.playerDataObject.exp += finalPoint; //Add Bonus point to exp
		DataCenter.instance.Save (); //Save data before star new stage
		Application.LoadLevel (NextStage);
	}

	public void PressHome()
	{
		Application.LoadLevel (1);
	}

}
