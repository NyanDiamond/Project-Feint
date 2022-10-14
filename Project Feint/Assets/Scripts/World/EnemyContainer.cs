using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{

    [SerializeField] GameObject[] enemiesInLevel;
    private bool isTriggered = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            foreach (GameObject i in enemiesInLevel)
            {
                EnemyCounter.upCount();
                EnemyCounter.enemies.Add(i);
            }
            Destroy(gameObject);
        }
    }
}