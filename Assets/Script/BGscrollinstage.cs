using UnityEngine;
using System.Collections;

public class BGscrollinstage : MonoBehaviour {
	public float scrollSpeedfixed,scrollSpeed;
	private Renderer renderer;
	
	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		scrollSpeed = scrollSpeedfixed;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Repeat (Time.time * scrollSpeed, 1);
		Vector2 offset = new Vector2 (x, 0);
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
		if (DataCenter.instance.playerDataObject.EndStage == true) {
			scrollSpeed = 0f;
		}else if (DataCenter.instance.sceneDataObject.NextEnd == false) {
			scrollSpeed = 0f;
		}else if (DataCenter.instance.sceneDataObject.NextEnd == true) {
			scrollSpeed = scrollSpeedfixed;
		}
	}
}
