using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static int count=0;
    public static List<GameObject> enemies = new List<GameObject>();
    public static bool countChanged = false;
    private GameObject[] doorsave;
    public static LightController mainLight;

    private void Awake()
    {
        enemies = new List<GameObject>();
        count = 0;
        doorsave = GameObject.FindGameObjectsWithTag("Door");
        mainLight = GameObject.FindGameObjectWithTag("MainCamera").transform.Find("Light").GetComponent<LightController>();
    }
    private void LateUpdate()
    {
        if (count <= 0 && countChanged)
        {
            Debug.Log("All enemies dead");
            countChanged = false;
            foreach (GameObject temp in doorsave)
            { 
                temp.SetActive(false);
            }
            mainLight.AllEnemiesDead();
        }
        else if (countChanged)
        {
            Debug.Log("Enemy count: " + count);
            countChanged = false;
            foreach (GameObject temp in doorsave)
            {
                temp.SetActive(true);
            }
        }
      
    }

    public static void upCount()
    {
        count++;
        countChanged = true;
        mainLight.StealthStart();
    }

    public static void downCount()
    {
        count--;
        countChanged = true;
    }

    public static void StealthBreak()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovementBehavior>().StealthBreak();
        }
		mainLight.StealthBreak();
    }

    public static void TeleporterCheck()
    {
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovementBehavior>().TeleporterCheck();
        }
    }
}
