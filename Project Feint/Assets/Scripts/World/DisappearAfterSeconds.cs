using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
public class DisappearAfterSeconds : MonoBehaviour
{
    public float lifeTime;
    public int flashes;
    public Color normal;
    public Color transparent;
    private SpriteShapeRenderer sr;
	private void Start()
	{
        sr = GetComponent<SpriteShapeRenderer>();
    }
	public void StartDisappearing()
    {
        StartCoroutine(Disappear(lifeTime));
    }
    

    IEnumerator Disappear(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        int temp = 0;

        while(temp<flashes)
        {
            yield return new WaitForSeconds(0.2f);
            sr.color = transparent;
            yield return new WaitForSeconds(0.2f);
            sr.color = normal;
            temp++;
        }
        Destroy(gameObject);
    }
}
