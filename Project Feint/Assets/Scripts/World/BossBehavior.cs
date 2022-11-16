using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehavior: MonoBehaviour
{
    bool shieldUp = false;
    float maxHealth = 18;
    float health = 18;
    [SerializeField] SpawnableEnemy[] wave1;
    [SerializeField] SpawnableEnemy[] wave2;
    [SerializeField] SpawnableEnemy[] wave3;
    [SerializeField] Vector2[] spawnPoints;
    [SerializeField] GameObject shield, explosions, finalBarrier, healthBar;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health == maxHealth && collision.CompareTag("Player_Attack"))
		{
            healthBar.SetActive(true);
		}
        if (!shieldUp && collision.CompareTag("Player_Attack"))
        {
            health--;
            healthBar.GetComponent<Slider>().value = health / maxHealth;
            if ((health+2) % 5 == 0)
            {
                shieldUp = true;
                shield.SetActive(true);
                SpawnWave();
            }
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
            case 13:
                foreach(SpawnableEnemy enemy in wave1)
                {
                    Debug.Log("spawning");
                    SpawnEnemy(enemy);
                }
                break;
            case 8:
                foreach (SpawnableEnemy enemy in wave2)
                {
                    SpawnEnemy(enemy);
                }
                break;
            case 3:
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
        if(health<=5)
        {
            shieldUp = true;
            finalBarrier.SetActive(true);
        }
    }

    void Finish()
    {
        StartCoroutine(Explosions());
        Debug.Log("Game Over");
        return;
    }
    
    private IEnumerator Explosions()
	{
        while (true)
		{
            yield return new WaitForSeconds(Random.Range(0.1f, 1));
            Instantiate(explosions, new Vector3(Random.Range(3.5f, 7.5f), Random.Range(-3.5f, -1), 0), Quaternion.identity);

        }
    }
}
