using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public Portal destination;
    public bool set;

	private void Start()
	{
        set = true;
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Teleporter")) && set)
        {
            destination.set = false;
            collision.gameObject.transform.SetPositionAndRotation(destination.transform.position, Quaternion.identity);
        }
    }
	private void OnTriggerExit2D(Collider2D collision)
	{
        set = true;
	}
}
