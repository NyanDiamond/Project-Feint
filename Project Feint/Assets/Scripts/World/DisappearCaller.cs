using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCaller : MonoBehaviour
{
    public List<DisappearAfterSeconds> objects = new List<DisappearAfterSeconds>();
    // Start is called before the first frame update

	private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < objects.Count; i++)
            objects[i].StartDisappearing();

        Destroy(gameObject);
	}
}
