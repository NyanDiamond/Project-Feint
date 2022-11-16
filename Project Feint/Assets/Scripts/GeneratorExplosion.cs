using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorExplosion : MonoBehaviour
{
	private void AnimationDone()
	{
		Destroy(gameObject);
	}
}
