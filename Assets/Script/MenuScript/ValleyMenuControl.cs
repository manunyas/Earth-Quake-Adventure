using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ValleyMenuControl : MonoBehaviour {
	public Button backBtn,s1;

	// Use this for initialization
	void Start () {
		backBtn = backBtn.GetComponent<Button> ();

		s1 = s1.GetComponent<Button> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressBack(){
		Application.LoadLevel (2);
	}
	public void PressS1()
	{
		Application.LoadLevel (4);
	}
}
