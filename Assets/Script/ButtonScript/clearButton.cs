using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clearButton : MonoBehaviour {
	public GameObject btnObj;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void Select()
	{
		btnObj.SetActive (false);
	}
}
