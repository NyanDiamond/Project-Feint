using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior: MonoBehaviour
{
    bool shieldUp = false;
    int health = 4;
    [SerializeField] SpawnableEnemy[] wave1;
    [SerializeField] SpawnableEnemy[] wave2;
    [SerializeField] SpawnableEnemy[] wave3;
    [SerializeField] Vector2[] spawnPoints;
    [SerializeField] GameObject shield, explosions, finalBarrier;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shieldUp && collision.CompareTag("Player_Attack"))
        {
            shieldUp = true;
            shield.SetActive(true);
            health--;
            SpawnWave();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (finalBarrier.activeInHierarchy && collision.gameObject.CompareTag("Teleporter"))
        {
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            Finish();
        }
        else if (collision.gameObject.CompareTag("Teleporter"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = (rb.position - collision.GetContact(0).point) * rb.velocity.magnitude;
        }
    }

    void SpawnWave()
    {
        switch(health)
        {
            case 3:
                foreach(SpawnableEnemy enemy in wave1)
                {
                    Debug.Log("spawning");
                    SpawnEnemy(enemy);
                }
                break;
            case 2:
                foreach (SpawnableEnemy enemy in wave2)
                {
                    SpawnEnemy(enemy);
                }
                break;
            case 1:
                foreach (SpawnableEnemy enemy in wave3)
                {
                    SpawnEnemy(enemy);
                }
                break;
        }
    }

    private void SpawnEnemy(SpawnableEnemy enemy)
    {
        GameObject temp = Instantiate(enemy.enemy, spawnPoints[enemy.spawnPos], Quaternion.identity);
        if (enemy.enemy.transform.childCount != 2)
        {
            EnemyCounter.enemies.Add(temp);
            temp.GetComponent<ExperimentalEnemyMovement>().StealthBreak();
        }
        else
        {
            EnemyCounter.enemies.Add(temp.transform.GetChild(0).gameObject);
            temp.GetComponentInChildren<ExperimentalEnemyMovement>().StealthBreak();
        }
        EnemyCounter.upCount();
        return;
    }


    public void EndWave()
    {
        shield.SetActive(false);
        shieldUp = false;
        if(health==1)
        {
            finalBarrier.SetActive(true);
        }
    }

    void Finish()
    {
        Debug.Log("Game Over");
        return;
    }
}
