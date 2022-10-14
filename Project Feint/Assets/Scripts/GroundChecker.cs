using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool grounded = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
}
