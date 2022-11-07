using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class BarrierAnimation : MonoBehaviour
{
	private SpriteShapeController ssController;
	public List<SpriteShape> shapes = new List<SpriteShape>();
	public float speed;
	private void Start()
	{
		StartCoroutine(periodicSwitch());
		ssController = GetComponent<SpriteShapeController>();
	}
	IEnumerator periodicSwitch()
	{
		while (true)
		{
			for (int i = 0; i < shapes.Count; i++)
			{
				yield return new WaitForSeconds(1 / speed);
				ssController.spriteShape = shapes[i];
				ssController.RefreshSpriteShape();
			}
		}
	}
}
