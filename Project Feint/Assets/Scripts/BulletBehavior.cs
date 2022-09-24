using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }

}
