using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{
    private GameObject mainCamera;
    public GameObject door;
    public bool isDark;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");   
    }

	private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyCounter.doorsave.Add(door);
        Debug.Log("Added door");
        if (isDark)
            EnemyCounter.EnterRoom(true);
        else
        {
            EnemyCounter.EnterRoom(false);
        }
	}
}
