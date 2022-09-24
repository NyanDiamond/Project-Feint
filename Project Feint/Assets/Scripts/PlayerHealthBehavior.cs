using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBehavior : MonoBehaviour
{
    public Color normal;
    public Color transparent;
    private float health = 3;
    [Tooltip("How many flashes the sprite makes to signify invulnerable (each flash is .4 seconds")]
    public int invulnerability;
    private PlayerMovement pm;
    private SpriteRenderer sr;
    private bool invulnerable = false;
    public Text healthBox;
    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        healthBox.text = "Health: 3";
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy_Attack") && !invulnerable)
        {
            Destroy(collision.gameObject);
            invulnerable = true;
            health--;
            healthBox.text = "Health: " + health;
            if (health > 0)
            {
                pm.Damaged();
                StartCoroutine(InvulnerabilityCD());
            }
            else if (health<=0)
            {
                pm.Death();
            }
        }
    }

    IEnumerator InvulnerabilityCD()
    {
        int temp = 0;

        while(temp<invulnerability)
        {
            yield return new WaitForSeconds(0.2f);
            sr.color = transparent;
            yield return new WaitForSeconds(0.2f);
            sr.color = normal;
            temp++;
        }
        invulnerable = false;
    }
}
