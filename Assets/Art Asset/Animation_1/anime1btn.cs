using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class anime1btn : MonoBehaviour {
	public Button skipButton;
	public Canvas s1,s2,s3,s4,s5;

	// Use this for initialization
	void Start () {
		skipButton = skipButton.GetComponent<Button> ();
		s1 = s1.GetComponent<Canvas> ();
		s2 = s2.GetComponent<Canvas> ();
		s3 = s3.GetComponent<Canvas> ();
		s4 = s4.GetComponent<Canvas> ();
		s5 = s5.GetComponent<Canvas> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void playAnime()
	{
	}

}
