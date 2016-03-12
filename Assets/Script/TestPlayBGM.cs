using UnityEngine;
using System.Collections;

public class TestPlayBGM : MonoBehaviour {
	public AudioClip bgmSound;
	private AudioSource soundsource;
	public int check;
	public float volume;

	// Use this for initialization
	void Start () {
		soundsource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (check == 0) {
			soundsource.PlayOneShot (bgmSound,volume);
		}else if (check != 0) {
			if (DataCenter.instance.sceneDataObject.StartStage == true) {
				soundsource.PlayOneShot (bgmSound,volume);
			}
			
		}
	
	}
}
