using UnityEngine;
using System.Collections;

public class stageSelect : MonoBehaviour {
	public int stageNo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PressBtn(){
		Application.LoadLevel (stageNo);
	}
}
