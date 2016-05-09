using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class LevelManager : MonoBehaviour {

	[System.Serializable]
	public class Level
	{
		public string LevelText;
		public int UnLocked;
		public bool IsInteractable;

		public Button.ButtonClickedEvent OnClickEvent;
	}

	public List<Level> LevelList;
	public GameObject levelButton;
	public Transform Spacer;



	// Use this for initialization
	void Start () {

		//DeleteAll ();
		FillList ();
		SaveAll ();
	}

	void FillList()
	{
		foreach (var level in LevelList) 
		{
			GameObject newbutton = Instantiate (levelButton) as GameObject;
			LevelButton button = newbutton.GetComponent<LevelButton> ();
			button.LevelText.text = level.LevelText;

			if (PlayerPrefs.GetInt ("Level" + button.LevelText.text) == 1) {
				level.UnLocked = 1;
				level.IsInteractable = true;
			}

			button.unlocked = level.UnLocked;
			button.GetComponent<Button> ().interactable = level.IsInteractable;

			button.GetComponent<Button> ().onClick.AddListener(() => loadLevels("Level" + button.LevelText.text));

			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text +  "_score") > 0)
			{
				button.Star1.SetActive(true);
			}

			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text +  "_score") >= 5000)
			{
				button.Star2.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Level"+ button.LevelText.text +  "_score") >= 9999)
			{
				button.Star3.SetActive(true);
			}



			newbutton.transform.SetParent (Spacer);
		}

		SaveAll ();
	}

	void SaveAll()
	{
		//if (PlayerPrefs.HasKey ("Level1")) 
		//{
		//	return;
		//}else
		{
			GameObject[] allButtons  = GameObject.FindGameObjectsWithTag ("LevelButton");
			foreach (GameObject buttons in allButtons) 
			{
				LevelButton button = buttons.GetComponent<LevelButton> ();
				PlayerPrefs.SetInt ("Level" + button.LevelText.text, button.unlocked);
			}
		}
	}
	

	void DeleteAll(){
		PlayerPrefs.DeleteAll ();
	}

	void loadLevels(string value){
		Application.LoadLevel (value);
	}

}


