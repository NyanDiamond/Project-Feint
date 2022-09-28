/*****************************************************************************
// File Name :         BackgroundParallax.cs
// Author :            Christian Young
// Creation Date :     September 28, 2022
//
// Brief Description : This script controls the movement of background
                       objects, providing visual depth
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float startPos;
    //private GameObject cam;
    private Camera cam;
    [SerializeField] private float parallaxFX;

    // Start is called before the first frame update
    void Start()
    {
        //cam = GameObject.Find("CM vcam1");
        cam = GameObject.FindObjectOfType<Camera>();
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallaxFX);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
