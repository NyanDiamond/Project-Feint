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

    private float movement;
    //player components
    private Animator an;
    private Rigidbody2D rb;
    private PlayerControls pc;
    //variables to keep track of certain aspects
    private bool jumping = false;
    private bool canAttack = true;
    private bool hit = true;
    private int attack = 1;
    private bool teleporterOut = false;
    private bool isAttacking = false;
    private Coroutine combo;
    // Start is called before the first frame update

    private void Awake()
    {
        pc = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
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

    private void Move()
    {
        rb.velocity = new Vector2(maxSpeed * movement, rb.velocity.y);
    }

    private void Jump()
    {
        
        if (!jumping)
        {
            jumping = true;
            an.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce);
        }
    }

    private void Teleport()
    {
        if (!teleporterOut)
        {
            Camera cam = GameObject.FindObjectOfType<Camera>();
            Vector2 lookPos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - throwPoint.transform.position;
            //create teleporter and add a force to throw it
            Instantiate(teleporter, throwPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(lookPos.normalized*throwPower);
            teleporterOut = true;
        }
        else
        {
            GameObject tp = GameObject.FindGameObjectWithTag("Teleporter");
            transform.position = tp.transform.position;
            TeleporterBehavior temp = tp.GetComponent<TeleporterBehavior>();
            //if TP is stuck to an enemy, destroy it
            if (temp.attached)
            {
                Destroy(tp.transform.parent.gameObject);
            }
            Destroy(tp);
            teleporterOut = false;

        }
    }

    private void Attack()
    {
        if (canAttack)
        {
            if(combo != null)
                StopCoroutine(combo);
            canAttack = false;
            isAttacking = true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player lands while jumping
        if (jumping && collision.gameObject.CompareTag("Floor") && transform.position.y > collision.gameObject.transform.position.y);
        {
            Debug.Log("landed");
            an.SetTrigger("Land");
            jumping = false;
        }

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
        Debug.Log("Combo Reset");
        attack = 1;
    }
}
