using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBehavior : MonoBehaviour
{

    [SerializeField] int health = 3;
    private Animator ar;
    private bool lookingLeft;
    private ExperimentalEnemyMovement em;
    public bool shielded = false;
    [SerializeField] bool isCamera = false;
   
    // Start is called before the first frame update
    void Start()
    {
        ar = GetComponent<Animator>();
        if(!isCamera)
        em = GetComponent<ExperimentalEnemyMovement>();
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

    //private void OnBecameVisible()
    //{
    //    EnemyCounter.upCount();
    //    EnemyCounter.enemies.Add(gameObject);
    //}

    private void OnDestroy()
    {
        if (isCamera)
        {
            EnemyCounter.cameras.Remove(gameObject);
        }
        else
        {
            EnemyCounter.downCount();
            EnemyCounter.enemies.Remove(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player_Attack"))
        {
            //Debug.Log("hit");
            Vector2 playerposition = collision.gameObject.transform.parent.transform.position;
            //Debug.Log("Player position=" + playerposition.ToString() + "\nEnemy position=" + transform.position.ToString() + "\nIs Facing Left: " + lookingLeft);
            if (!isCamera)
            {
                if (lookingLeft && playerposition.x > transform.position.x)
                {
                    health -= 3;
                }
                else if (!lookingLeft && playerposition.x < transform.position.x)
                {
                    health -= 3;
                }
                else if (!shielded)
                {
                    health--;
                    em.Damaged();
                }
                else
                {
                    em.Damaged();
                }
                if (health <= 0)
                {
                    ar.SetTrigger("Dead");
                    GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    GetComponent<BoxCollider2D>().enabled = false;
                    em.Dead();
                }
                else
                {
                    ar.SetTrigger("Hit");
                }
            }
            else
            {
                ar.SetTrigger("Dead");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<CameraBehavior>().Dead();
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
        //EnemyCounter.downCount();
        //EnemyCounter.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
