using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataCenter : MonoBehaviour {
	public static DataCenter instance; 

	public PlayerData playerDataObject;
	public SceneData sceneDataObject;

	//public float maxHP,exp;

	void Awake(){
		if (instance == null) 
		{
			DontDestroyOnLoad (gameObject);
			instance = this;

		}
		else if (instance != this) {
			Destroy (gameObject);
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PData data = new PData();
		data.maxHP = DataCenter.instance.playerDataObject.maxHP;
		data.exp = DataCenter.instance.playerDataObject.exp;

		bf.Serialize (file,data);
		file.Close ();
	}

	public void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
			PData data = (PData)bf.Deserialize (file);
			file.Close ();

			DataCenter.instance.playerDataObject.maxHP = data.maxHP;
			DataCenter.instance.playerDataObject.exp = data.exp;

		}
	}

}

[Serializable] //This class can save
class PData
{
	public float maxHP,exp;
}
	
