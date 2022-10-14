using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;
    public float throwPower;
    public GameObject teleporter;
    public GameObject throwPoint;
    private GroundChecker gr;
    private float movement;
    //player components
    private Animator an;
    private Rigidbody2D rb;
    private PlayerControls pc;
    //variables to keep track of certain aspects
    //private bool jumping = false;
    private bool grounded = true;
    private bool canAttack = true;
    private bool hit = true;
    private int attack = 1;
    //private bool teleporterOut = false;
    private bool isAttacking = false;
    private bool canTP = true;
    private bool isHit = false;
    public bool teleporting = false;
    
    private Coroutine combo;
    // Start is called before the first frame update

    private void Awake()
    {
        pc = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        gr = transform.Find("GroundCheck").GetComponent<GroundChecker>();
        combo = null;
    }

    private void OnEnable()
    {
        
        pc.Enable();
        pc.Default.Jump.performed += _ => Jump();
        pc.Default.Teleport.performed += _ => Teleport();
        pc.Default.Attack.performed += _ => Attack();
    }

    private void OnDisable()
    {
        pc.Disable();
    }
 

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isHit)
        {
            movement = pc.Default.Move.ReadValue<float>();
            //Check to see if the player is moving and set bool accordingly for animations
            if (movement != 0)
            {
                an.SetBool("isRunning", true);
                //if moving left
                if (movement < 0 && !isAttacking)
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                //if moving right
                else if (movement > 0 && !isAttacking)
                    transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else
                StartCoroutine(IdleCooldown());
            Move();
        }

        grounded = GroundCheck();
        if (!grounded && rb.velocity.y > 0)
        {
            //Debug.Log("Jumping");
            an.SetBool("Jumping", true);
        }
        if (grounded && rb.velocity.y <= 0)
        {
            //Debug.Log("Landed");
            an.SetBool("Jumping", false);
            if(!canTP && !teleporting)
            {
                canTP = true;
            }
        }
    }

    private void Move()
    {
        float yVel = rb.velocity.y;
        if (!isHit)
            rb.velocity = new Vector2(maxSpeed * movement,yVel);
    }

    private void Jump()
    {
        
        if (grounded && !isHit)
        {
            //jumping = true;
            //an.SetBool("Jumping", true);
            rb.AddForce(transform.up * jumpForce);
        }
    }

    private bool GroundCheck()
    {   
        Debug.Log(gr.grounded);
        return gr.grounded;
        
    }

    private void Teleport()
    {
        GameObject tp = GameObject.FindGameObjectWithTag("Teleporter");
        if (canTP && !isHit)
        {
            
            //jumping = true;
            if (tp == null)
            {
                Camera cam = GameObject.FindObjectOfType<Camera>();
                Vector2 lookPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - throwPoint.transform.position;
                //create teleporter and add a force to throw it
                Instantiate(teleporter, throwPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(lookPos.normalized * throwPower);
                //teleporterOut = true;
            }
            else
            {
                teleporting = true;
                canTP = false;
                if (tp.transform.parent == null)
                {
                    transform.position = tp.transform.position;
                }
                else if (tp.transform.position.y < tp.transform.parent.position.y)
                {
                    transform.position = tp.transform.position - Vector3.up;
                }
                else
                    transform.position = tp.transform.position;
                EnemyCounter.TeleporterCheck();
                TeleporterBehavior temp = tp.GetComponent<TeleporterBehavior>();
                //if TP is stuck to an enemy, destroy it
                if (temp.attached)
                {
                    tp.transform.parent.GetComponent<EnemyHealthBehavior>().instantDeath();
                }
                Destroy(tp);
                //teleporterOut = false;
                teleporting = false;
            }
        }
    }

    private void Attack()
    {
        if (canAttack && !isHit)
        {
            if(combo != null)
                StopCoroutine(combo);
            canAttack = false;
            isAttacking = true;
            hit = false;
            switch (attack)
            {
                case 1:
                    an.SetTrigger("Attack1");
                    attack++;
                    break;
                case 2:
                    an.SetTrigger("Attack2");
                    attack++;
                    break;
                case 3:
                    an.SetTrigger("Attack3");
                    attack++;
                    break;
            }
        }
    }

    private void AttackEnd()
    {
        isAttacking = false;
        if (hit && attack != 4)
        {
            combo = StartCoroutine(ComboWindow());
        }
        else
        {
            attack = 1;
        }
        canAttack = true;
    }

    public void AttackHit()
    {
        hit = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if the player lands while jumping
        /*if (jumping && collision.gameObject.CompareTag("Floor") && transform.Find("Target").position.y > collision.gameObject.transform.position.y)
        {
           
            an.SetTrigger("Land");
            jumping = false;
        }
        if (!canTP && collision.gameObject.CompareTag("Floor") && transform.Find("Target").position.y > collision.gameObject.transform.position.y)
        {
            canTP = true;
        }*/

    }

    IEnumerator IdleCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        {
            if (movement == 0)
                an.SetBool("isRunning", false);
        }
    }

    IEnumerator ComboWindow()
    {
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("Combo Reset");
        attack = 1;
    }

    public void Damaged()
    {
        isHit = true;
        an.SetTrigger("Hit");
        rb.velocity = (-transform.forward) * 0.1f;
    }

    public void Death()
    {
        an.SetTrigger("Death");
        isHit = true;
    }
    private void OutOfHitstun()
    {
        isHit = false;
    }
}
