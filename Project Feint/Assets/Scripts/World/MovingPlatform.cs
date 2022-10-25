using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Tooltip("Start with its starting position")]
    [SerializeField] Vector2[] movePoints;
    [SerializeField] float speed;

    private bool forward = true;
    private int movePoint = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, movePoints[movePoint])<0.001)
        {
            if(forward)
            {
                if(movePoint+1>=movePoints.Length)
                {
                    forward = false;
                    movePoint--;
                }
                else
                {
                    movePoint++;
                }
            }
            else
            {
                if(movePoint <= 0)
                {
                    forward = true;
                    movePoint++;
                }
                else
                {
                    movePoint--;
                }
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, movePoints[movePoint], speed * Time.deltaTime);
    }
}
