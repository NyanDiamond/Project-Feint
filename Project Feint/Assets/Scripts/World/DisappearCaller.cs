using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearCaller : MonoBehaviour
{
    public List<DisappearStats> objects = new List<DisappearStats>();
    private EnemyInfoController enemyInfoScript;
    public int time;
    // Start is called before the first frame update
    private void Start()
	{
        enemyInfoScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyInfoController>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundCheck"))
		{
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].obj != null)
                    StartCoroutine(HandleDisappear(objects[i].waitTime, objects[i].obj));
            }
            enemyInfoScript.EnterTimedRoom(time);
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private IEnumerator HandleDisappear(float seconds, DisappearAfterSeconds obj)
	{
        yield return new WaitForSeconds(seconds);
        Debug.Log(obj.name + "Disappearing");
        if (obj.isActiveAndEnabled)
            obj.StartDisappearing();
	}
	private void OnDisable()
	{
        StopAllCoroutines();
	}
    //private IEnumerator ()
}
[System.Serializable] public class DisappearStats
{
    public DisappearAfterSeconds obj;
    public float waitTime;
}
