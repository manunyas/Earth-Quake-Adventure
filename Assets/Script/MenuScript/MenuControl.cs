using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

	public Canvas exitMenu;
	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () 
	{
		exitMenu = exitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		exitMenu.enabled = false;
	}

	public void exitPress ()
	{
		exitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void noPress ()
	{
		exitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void StartLevel ()
	{
		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}

}
