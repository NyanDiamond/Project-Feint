using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextRoomEntryZone;
    public GameObject environment;
    public int currentRoom;
    public int nextRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            environment.transform.GetChild(nextRoom - 1).gameObject.SetActive(true);
            collision.gameObject.transform.SetPositionAndRotation(nextRoomEntryZone.transform.position, Quaternion.identity);
            environment.transform.GetChild(currentRoom - 1).gameObject.SetActive(false);
        }
    }
}
