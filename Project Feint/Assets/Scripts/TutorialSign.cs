using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSign : MonoBehaviour
{
    [SerializeField] List<string> text = new List<string>();
    private bool open = false;
    private int textPos;
    [SerializeField] GameObject textBox;
    [SerializeField] Text textBoxText;
    

    void OnContinue()
    {
        if(textBox.activeInHierarchy)
        {
            textPos++;
            if(textPos >= text.Count)
            {
                textPos = 0;
                textBox.SetActive(false);
            }
            textBoxText.text = text[textPos];
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            textPos = 0;
            textBoxText.text = text[textPos];
            textBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            textPos = 0;
            textBoxText.text = text[textPos];
            textBox.SetActive(false);
        }
    }
}
