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
            transform.position = transform.parent.Find("Center Point Soldier").position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Vector3 safescale = transform.lossyScale;
            GetComponent<CircleCollider2D>().isTrigger = true;
            GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
            transform.parent = collision.gameObject.transform;
            transform.rotation = Quaternion.identity;
            transform.localScale = new Vector3(safescale.x * 1 / transform.parent.localScale.x, safescale.y * 1 / transform.parent.localScale.y);
            
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<CircleCollider2D>().isTrigger = true;
            attached = true;
            transform.parent = collision.gameObject.transform;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            transform.position = transform.parent.Find("Center Point Soldier").position;
        }
    }
}
