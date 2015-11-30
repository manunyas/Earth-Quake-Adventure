using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextButton : MonoBehaviour {
	public Canvas Mission;
	public Text missionTxt, knowledgeTxt, head1, head2;
	public Button nextBtn;
	public int countNextpress,countNextToEnd;

	// Use this for initialization
	void Start () {
		Mission = Mission.GetComponent<Canvas> ();
		missionTxt = missionTxt.GetComponent<Text> ();
		knowledgeTxt = knowledgeTxt.GetComponent<Text> ();
		head1 = head1.GetComponent<Text> ();
		head2 = head2.GetComponent<Text> ();
		nextBtn = nextBtn.GetComponent<Button> ();

		knowledgeTxt.enabled = false;
		head2.enabled = false;

	}

	void Update()
	{
		countNextBtn ();
	}
	
	public void PressNextBtn()
	{
		countNextpress += 1;
	}

	void countNextBtn()
	{
		if (countNextpress == countNextToEnd) {
			DataCenter.instance.sceneDataObject.NextEnd = true;
			gameObject.SetActive (false);
		}else if (countNextpress == 1) {
			knowledgeTxt.enabled = true;
			head2.enabled = true;
			missionTxt.enabled = false;
			head1.enabled = false;
		}
	}
}
