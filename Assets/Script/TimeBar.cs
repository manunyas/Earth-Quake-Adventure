using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour {
	public Color minHPcolor;
	public Color maxHPcolor;
	public Color halfHPcolor;
	public Image fill;
	public float dangerHP,halfHP;

	// Use this for initialization
	void Start () {
		GetComponent<Slider> ().maxValue = DataCenter.instance.playerDataObject.maxHP;
		fill.color = maxHPcolor;
		dangerHP = 10f * DataCenter.instance.playerDataObject.maxHP / 100;
		halfHP = 50f * DataCenter.instance.playerDataObject.maxHP / 100;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Slider> ().value = DataCenter.instance.playerDataObject.currentHP;
		changeColor ();
	}
	

	public void changeColor()
	{
		if (GetComponent<Slider>().value < dangerHP && DataCenter.instance.playerDataObject.Hit == false ) {
			fill.color = minHPcolor;
		}
		else if (GetComponent<Slider>().value > dangerHP && GetComponent<Slider>().value < halfHP && DataCenter.instance.playerDataObject.Hit == false) {
			fill.color = halfHPcolor;
		}
		else if (GetComponent<Slider>().value < dangerHP && DataCenter.instance.playerDataObject.Hit == true) {
			fill.color = Color.red;
		}
		else if (GetComponent<Slider>().value > dangerHP && GetComponent<Slider>().value < halfHP && DataCenter.instance.playerDataObject.Hit == true) {
			fill.color = Color.red;
		}
		else if (GetComponent<Slider>().value > dangerHP && GetComponent<Slider>().value > halfHP && DataCenter.instance.playerDataObject.Hit == true) {
			fill.color = Color.red;
		}
		else if (GetComponent<Slider>().value > dangerHP && GetComponent<Slider>().value > halfHP && DataCenter.instance.playerDataObject.Hit == false) {
			fill.color = maxHPcolor;
		}
	}

}
