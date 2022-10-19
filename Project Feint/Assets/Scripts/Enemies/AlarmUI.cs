using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmUI : MonoBehaviour
{
    public Color safe;
    public Color warning;
    public Color spotted;
    public Color alarmRaised;
    private GameObject alarm;
    private SpriteRenderer sr;
    
    //public Text alarmText;

    private void Start()
    {
        alarm = transform.Find("Alarm").gameObject;
        sr = alarm.GetComponent<SpriteRenderer>();
        sr.color = safe;
        //alarmText.text = "Safe";
    }

    public void Safe()
    {
        sr.color = safe;
        //alarmText.text = "Safe";
    }

    public void Warning()
    {
        sr.color = warning;
        //alarmText.text = "Warning";
    }

    public void Spotted()
    {
        sr.color = spotted;
        //alarmText.text = "Spotted";
    }

    public void AlarmRaised()
    {
        sr.color = alarmRaised;

        SoundPlayer sp = GameObject.Find("GameController").GetComponent<SoundPlayer>();
        //sp.PlaySound1();
        //alarmText.text = "Alarm Raised!";
    }

    private void OnDestroy()
    {
        Destroy(alarm);
    }
}
