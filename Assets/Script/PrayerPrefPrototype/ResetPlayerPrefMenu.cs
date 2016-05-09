using UnityEngine;
using UnityEditor;
using System.Collections;

public class ResetPlayerPrefMenu : MonoBehaviour {

	[MenuItem("Assets/ResetPlayerPref")]
	public static void ResetPlayerPref()
	{
		PlayerPrefs.DeleteAll ();
	}
}
