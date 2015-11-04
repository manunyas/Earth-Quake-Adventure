using UnityEngine;
using System.Collections;

public class BGscroll : MonoBehaviour {
	public float scrollSpeed;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, 0);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		//DataCenter.instance.sceneDataObject.RunScene = false;

		//Stop Motion
		if (DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage) {
			scrollSpeed = 0f;
		}
		if (DataCenter.instance.playerDataObject.currentHP < 0) {
			scrollSpeed = 0f;
		}
	}
}
