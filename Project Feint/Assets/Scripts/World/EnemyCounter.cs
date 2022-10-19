using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static int count=0;
    public static List<GameObject> enemies = new List<GameObject>();
    public static List<GameObject> cameras = new List<GameObject>();
    public static bool countChanged = false;
    public static List<GameObject> doorsave = new List<GameObject>();
    public static LightController mainLight;
    public static bool stealth = true;

    private void Awake()
    {
        enemies = new List<GameObject>();
        count = 0;
        doorsave = new List<GameObject>();
        cameras = new List<GameObject>();
        countChanged = false;
        stealth = true;
        //doorsave = GameObject.FindGameObjectsWithTag("Door");
        mainLight = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("Light").GetComponent<LightController>();
    }
    private void LateUpdate()
    {
        if (count <= 0 && countChanged && !stealth)
        {
            //Debug.Log("All enemies dead");
            countChanged = false;
            foreach (GameObject temp in doorsave)
            { 
                temp.SetActive(false);
            }
            mainLight.AllEnemiesDead();
            SoundPlayer sp = GameObject.Find("GameController").GetComponent<SoundPlayer>();
            sp.PlaySound2();
        }
        else if (countChanged)
        {
            Debug.Log("Enemy count: " + count);
            countChanged = false;
            /*foreach (GameObject temp in doorsave)
            {
                temp.SetActive(true);
            }*/
        }
      
    }
    public static void upCount()
    {
        count++;
        countChanged = true;
    }

    public static void downCount()
    {
        count--;
        countChanged = true;
    }

    public static void BeginStealth()
	{
        foreach (GameObject temp in doorsave)
        {
            temp.SetActive(false);
        }
        mainLight.StealthStart();
        stealth = true;
    }
    public static void EnterRoom(bool isDark)
	{
        foreach (GameObject temp in doorsave)
        {
            temp.SetActive(false);
        }
        if (isDark)
		{
            mainLight.EnterDarkRoom();
		}
		else
		{
            mainLight.EnterBrightRoom();
		}
        stealth = true;
    }

    public static void StealthBreak()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<ExperimentalEnemyMovement>().StealthBreak();
        }
        foreach(GameObject camera in cameras)
        {
            camera.GetComponent<CameraBehavior>().StealthBreak();
        }
		mainLight.StealthBreak();

        foreach (GameObject temp in doorsave)
        {
            temp.SetActive(true);
        }
        stealth = false;
    }

    public static void TeleporterCheck()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<ExperimentalEnemyMovement>().TeleporterCheck();
        }
    }
}
