using UnityEngine;
using System.Collections;

public class DataCenter : MonoBehaviour {
	public static DataCenter instance; 
	// Use this for initialization
	public PlayerData playerDataObject;
	public SceneData sceneDataObject;

	void Awake(){
		instance = this;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
