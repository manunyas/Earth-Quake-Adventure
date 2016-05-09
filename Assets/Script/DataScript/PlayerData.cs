using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {


	public bool Hit = false, EndStage = false, Sound;
	public float maxHP,maxStage,exp, maxExp, level;
	public float damage;
	public float currentHP,currentStage,PointCountFloat;
	public int n,CoinCount,PointCount,bonusPointCount,specialCount;

	void Start() 
	{
		
	}

	void Update () {
		CountStage ();
		CountPoint ();
		EndStageCheck ();
		CheckLevel ();
	}


	void CountStage ()
	{
		if (DataCenter.instance.sceneDataObject.StartStage == true) {
			if (currentHP > 0) {
				currentStage += Time.deltaTime;
			}
			if (currentHP < 0) {
				currentStage += 0;
			}
		}

	}

	void CountPoint()
	{
		if (PointCountFloat != PointCount && PointCountFloat <= PointCount) {
			PointCountFloat += Time.deltaTime*n;
		}

	}

	void EndStageCheck()
	{
		//End way
		if (DataCenter.instance.playerDataObject.currentStage > DataCenter.instance.playerDataObject.maxStage) {
			EndStage = true;
		}
		//Out of HP
		else if (DataCenter.instance.playerDataObject.currentHP < 0) {
			EndStage = true;
		}
	}
		
	void CheckLevel()
	{
		//====Set Level EXP and HP====
		if (exp < 1138) {
			level = 1;
			maxExp = 1138;
			maxHP = 70; //1
		}else if (exp < 2157) {
			level = 2;
			maxExp = 2157;
			maxHP = 72; //2
		}else if (exp < 4089) {
			level = 3;
			maxExp = 4089;
			maxHP = 74; //3
		}else if (exp < 7752) {
			level = 4;
			maxExp = 7752;
			maxHP = 78; //4
		}else if (exp < 14697) {
			level = 5;
			maxExp = 14697;
			maxHP = 80; //5
		}else if (exp < 27864) {
			level = 6;
			maxExp = 27864;
			maxHP = 82; //6
		}else if (exp < 52827) {
			level = 7;
			maxExp = 52827;
			maxHP = 84; //7
		}else if (exp < 100155) {
			level = 8;
			maxExp = 100155;
			maxHP = 88; //8
		}else if (exp < 189884) {
			level = 9;
			maxExp = 189884;
			maxHP = 90; //9
		}else if (exp < 360000) {
			level = 10;
			maxExp = 360000;
			maxHP = 92; //10
		}else if (exp < 495690) {
			level = 11;
			maxExp = 495690;
			maxHP = 94; //11
		}else if (exp < 682524) {
			level = 12;
			maxExp = 682524;
			maxHP = 96; //12
		}else if (exp < 939778) {
			level = 13;
			maxExp = 939778;
			maxHP = 98; //13
		}else if (exp < 1293995) {
			level = 14;
			maxExp = 1293995;
			maxHP = 100; //14
		}else if (exp < 1781724) {
			level = 15;
			maxExp = 1781724;
			maxHP = 102; //15
		}else if (exp < 2453284) {
			level = 16;
			maxExp = 2453284;
			maxHP = 104; //16
		}else if (exp < 3377967) {
			level = 17;
			maxExp = 3377967;
			maxHP = 108; //17
		}else if (exp < 4362963) {
			level = 18;
			maxExp = 4362963;
			maxHP = 110; //18
		}else if (exp < 5635177) {
			level = 19;
			maxExp = 5635177;
			maxHP = 120; //19
		}else if (exp < 6907391) {
			level = 20;
			maxExp = 6907391;
			maxHP = 130; //20
		}else if (exp < 9400688) {
			level = 21;
			maxExp = 9400688;
			maxHP = 140; //21
		}else if (exp < 11893985) {
			level = 22;
			maxExp = 11893985;
			maxHP = 150; //22
		}else if (exp < 14387282) {
			level = 23;
			maxExp = 14387282;
			maxHP = 160; //23
		}else if (exp < 16880580) {
			level = 24;
			maxExp = 16880580;
			maxHP = 170; //24
		}else {
			level = 25;
			maxExp = 16880580;
			maxHP = 180; //25
		}
	}

}
		
