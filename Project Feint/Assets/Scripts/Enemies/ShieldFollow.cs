using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFollow : MonoBehaviour
{
    private Transform shieldEnemy;
    private Transform shield;
    [SerializeField] float offset;
    // Start is called before the first frame update
    void Start()
    {
        shieldEnemy = transform.GetChild(0);
        shield = transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount<2)
        {
            Destroy(gameObject);
        }
        shield.position = (Vector2)shieldEnemy.position + new Vector2(0, .54f) + (Vector2)shieldEnemy.right * offset;
    }
}
