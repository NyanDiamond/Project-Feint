using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorTriggerLastRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextLevel;
    public int checkpointNumber;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /*environment.transform.GetChild(nextRoom - 1).gameObject.SetActive(true);
            EnemyCounter.enemies.Clear();
            EnemyCounter.count = 0;
            collision.gameObject.transform.SetPositionAndRotation(nextRoomEntryZone.transform.position, Quaternion.identity);
            environment.transform.GetChild(currentRoom - 1).gameObject.SetActive(false);*/
            Save.SaveCheckpoint(checkpointNumber);
            SceneManager.LoadScene(nextLevel);
        }
    }
	private void OnDisable()
	{
        EnemyCounter.doorsave.Remove(gameObject);
	}
}
