using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBehavior : MonoBehaviour
{

    private int health = 3;
    private Animator ar;
    private bool lookingLeft;
    // Start is called before the first frame update
    void Start()
    {
        ar = GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(transform.rotation.y);
        if (transform.rotation.eulerAngles.y == 180f)
        {
            lookingLeft = true;
        }
        else if (transform.rotation.eulerAngles.y == 0f)
        {
            lookingLeft = false;
        }
    }

    private void OnBecameVisible()
    {
        EnemyCounter.upCount();
        EnemyCounter.enemies.Add(gameObject);
    }

    private void OnBecameInvisible()
    {
        EnemyCounter.downCount();
        EnemyCounter.enemies.Remove(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Attack"))
        {
            Vector2 playerposition = collision.gameObject.transform.parent.transform.position;
            //Debug.Log("Player position=" + playerposition.ToString() + "\nEnemy position=" + transform.position.ToString() + "\nIs Facing Left: " + lookingLeft);
            if (lookingLeft && playerposition.x > transform.position.x)
            {
                health -= 3;
            }
            else if (!lookingLeft && playerposition.x < transform.position.x)
            {
                health -= 3;
            }
            else
            {
                health--;
            }
            if (health <= 0)
            {
                ar.SetTrigger("Dead");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                ar.SetTrigger("Hit");
            }
        }
    }

    public void instantDeath()
    {
        ar.SetTrigger("Dead");
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
    }
    

    private void Dead()
    {
        EnemyCounter.downCount();
        EnemyCounter.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
