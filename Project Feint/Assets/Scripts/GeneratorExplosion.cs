using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorExplosion : MonoBehaviour
{
    private void Start()
    {
        GameObject.FindObjectOfType<SoundPlayer>().PlaySound14();
    }
    private void AnimationDone()
	{
		Destroy(gameObject);
	}
}
