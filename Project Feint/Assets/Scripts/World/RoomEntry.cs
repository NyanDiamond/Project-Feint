using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEntry : MonoBehaviour
{
    private GameObject mainCamera;
    public bool isDark;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");   
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (isDark)
            mainCamera.transform.GetChild(0).GetComponent<LightController>().EnterDarkRoom();
		else {
            mainCamera.transform.GetChild(0).GetComponent<LightController>().EnterBrightRoom();
        }
	}
}
