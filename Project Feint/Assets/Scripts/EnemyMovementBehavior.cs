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
    public GameObject bullet;
    public GameObject shootPoint;
    [Tooltip("Degrees of offset for specific bullet sprite to look correct")]
    public float rotationFix;
    [Tooltip("How long is the hitstun of the enemy")]
    public float hitstun;
    private bool aware = false;
    private bool alarmSounded = false;
    private bool lookingLeft;
    private float attackCooldown = 0;

    
  

    private Rigidbody2D rb;
    private Animator an;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        playerObject = GameObject.Find("Player");
        player = playerObject.transform.Find("Target");
        pm = playerObject.GetComponent<PlayerMovement>();
        StartCoroutine(ChargeAttack());
       
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (aware)
        {
            Move();
        }
        
    }
   

    void LateUpdate()
    {
        if (aware)
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

        if (attackCooldown >= 2f)
        {
            an.SetBool("Attacking", true);
        }
        
    }

 

    private void Attacked()
    {
        attackCooldown = 0;
        an.SetBool("Attacking", false);
    }

    private void RangedAttack()
    {
        float angle = Mathf.Atan2(shootPoint.transform.position.y - player.position.y, shootPoint.transform.position.x - player.position.x) * Mathf.Rad2Deg + rotationFix;
        Instantiate(bullet, shootPoint.transform.position, Quaternion.Euler(0,0,angle));
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
        alarmSounded = true;
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

    public void Damaged()
    {
        StartCoroutine(HitStun());
    }

    private IEnumerator HitStun()
    {
        aware = false;
        yield return new WaitForSeconds(hitstun);
        aware = true;
    }

    private IEnumerator ChargeAttack()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if(aware && Vector2.Distance(player.position, transform.position)<tooFarRange)
            {
                attackCooldown += 0.1f;
            }
        }
    }
  
}
