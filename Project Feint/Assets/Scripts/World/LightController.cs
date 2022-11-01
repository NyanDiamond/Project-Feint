using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
	private Text enemyInfoText;
	private void Start()
	{
		enemyInfoText = GameObject.FindGameObjectWithTag("EnemyInfo").GetComponent<Text>();
		StealthStart();
	}
	public void StealthBreak()
	{
		GetComponent<Light2D>().pointLightOuterRadius = 10;
		enemyInfoText.fontSize = 20;
		enemyInfoText.text = "! [YOU'VE BEEN SPOTTED] !";
		enemyInfoText.color = Color.red;
	}
	public void AllEnemiesDead()
	{
		GetComponent<Light2D>().pointLightOuterRadius = 10;
		enemyInfoText.fontSize = 20;
		enemyInfoText.text = "! [ALL ENEMIES DEAD] !     -escape through the door on the right-";
		enemyInfoText.color = Color.green;
	}
	public void StealthStart()
	{
		GetComponent<Light2D>().pointLightOuterRadius = 6;
		enemyInfoText.fontSize = 15;
		enemyInfoText.text = "[Stealth Mode]";
		enemyInfoText.color = Color.yellow;
	}
	public void EnterDarkRoom()
	{
		GetComponent<Light2D>().pointLightOuterRadius = 0;
		enemyInfoText.fontSize = 15;
		enemyInfoText.text = "[Stealth Mode]";
		enemyInfoText.color = Color.yellow;
	}
	public void EnterBrightRoom()
	{
		StealthStart();
	}
}
