using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContainer : MonoBehaviour
{

    [SerializeField] GameObject[] enemiesInLevel;
    [SerializeField] GameObject[] camerasInLevel;
    [SerializeField] GameObject[] turretsInLevel;
    private bool isTriggered = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;

            EnemyCounter.enemies.Clear();
            EnemyCounter.count = 0;
            foreach (GameObject i in enemiesInLevel)
            {
                EnemyCounter.upCount();
                EnemyCounter.enemies.Add(i);
            }
            EnemyCounter.cameras.Clear();
            foreach(GameObject i in camerasInLevel)
            {
                EnemyCounter.cameras.Add(i);
            }
            EnemyCounter.turrets.Clear();
            foreach(GameObject i in turretsInLevel)
            {
                EnemyCounter.turrets.Add(i);
            }
            DestroyAfterSeconds(0.5f);
        }
    }
    private IEnumerator DestroyAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(gameObject);
    }

}
