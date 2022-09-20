using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MonoBehaviour
{
    private GameObject playerObject;
    private PlayerMovement pm;
    private Transform player;
    public float movementSpeed = 3f;
    public float tooCloseRange = 4f;
    public float tooFarRange = 6f;
    private bool aware = false;
    private bool lookingLeft;

    
  

    private Rigidbody2D rb;
    private Animator an;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        playerObject = GameObject.Find("Player");
        player = playerObject.transform;
        pm = playerObject.GetComponent<PlayerMovement>();
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (aware && !pm.teleporting)
        {
            Move();
        }
        
    }
   

    void LateUpdate()
    {
        
        if (aware && !pm.teleporting)
        {
            if (player.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                lookingLeft = true;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                lookingLeft = false;
            }
        }
        
    }

    private void Move()
    {
        float distance = Vector2.Distance(player.position, transform.position);
        //Debug.Log(distance);
        if (distance > tooFarRange)
        {
            Debug.Log("Too far");
            rb.velocity = new Vector2(movementSpeed * transform.right.x, rb.velocity.y);
            an.SetBool("Walking", true);
            an.SetBool("Forward", true);
        }
        else if (distance < tooCloseRange)
        {
            Debug.Log("Too close");
            rb.velocity = new Vector2(movementSpeed / 2 * -transform.right.x, rb.velocity.y);
            an.SetBool("Walking", true);
            an.SetBool("Forward", false);
        }
        else if (distance > tooCloseRange && distance < tooFarRange)
        {
            Debug.Log("In range");
            rb.velocity = new Vector2(0, rb.velocity.y);
            an.SetBool("Walking", false);
            an.SetBool("Forward", true);
        }
    }

    public void StealthBreak()
    {
        aware = true;
    }

    public void TeleporterCheck()
    {
        if (aware)
        {

            Debug.Log("Teleporter Check");
            if (lookingLeft && player.position.x > transform.position.x)
            {
                Debug.Log("Dazed");
                aware = false;
                StartCoroutine(Dazed());
            }
            else if (!lookingLeft && player.position.x < transform.position.x)
            {
                Debug.Log("Dazed");
                aware = false;
                StartCoroutine(Dazed());
            }

        }
    }

    private IEnumerator Dazed()
    {
        yield return new WaitForSeconds(1f);
        aware = true;
    }

  
}
