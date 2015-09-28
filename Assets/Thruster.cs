using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {
	public float scale = 1f;
	public RectTransform rectTransform;
	public float barsTime = 0f;
	// Use this for initialization
	void Start () 
	{

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		scaleTime ();
		rectTransform.localScale = new Vector3 (scale, rectTransform.localScale.y, rectTransform.localScale.z);
	
	}

	void scaleTime ()
	{
		for (int i = 0; i < barsTime; i++) {
			scale = scale - 0.0001f;
		}
	}
}
