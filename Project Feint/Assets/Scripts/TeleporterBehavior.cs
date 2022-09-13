using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterBehavior : MonoBehaviour
{

    public bool attached = false;
    // Start is called before the first frame update

    private void Update()
    {
        if (attached)
        {
            transform.position = transform.parent.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            attached = true;
            transform.parent = collision.gameObject.transform;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
