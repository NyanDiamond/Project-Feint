using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
public class DisappearAfterSeconds : MonoBehaviour
{
    [Header("Set lifetime with a DisappearCaller script")]
    public int flashes;
    public Color normal;
    public Color transparent;
    public bool isEnergyBarrier;
    private SpriteRenderer sr;
	private void Start()
	{
        sr = GetComponent<SpriteRenderer>();
    }
	public void StartDisappearing()
    {
        StartCoroutine(Disappear());
    }

	IEnumerator Disappear()
    {
        if (!isEnergyBarrier)
		{
            int temp = 0;

            while (temp < flashes)
            {
                //Debug.Log("Started disappearing!");
                yield return new WaitForSeconds(0.3f);
                sr.color = transparent;
                yield return new WaitForSeconds(0.3f);
                sr.color = normal;
                temp++;
            }
        }
        
        Destroy(gameObject);
    }
}
