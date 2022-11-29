using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DialogBehavior : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textDisplay;
    [SerializeField] float delay;
    [SerializeField] TextObject[] dialog;
    [SerializeField] string nextScene;
    private string[] currentLoggedText;
    private string currentColor;
    private int current = 0;
    private string currentText;
    // Start is called before the first frame update
    void Start()
    {
        currentLoggedText = new string[dialog.Length];
        currentText = dialog[current].text;
        currentColor = "#" + ColorUtility.ToHtmlStringRGBA(dialog[current].color);
        StartCoroutine(Scroll());
    }

    void Next()
    {
        current++;
        if(current < dialog.Length)
        {
            currentText = dialog[current].text;
            currentColor = "#" + ColorUtility.ToHtmlStringRGBA(dialog[current].color);
            StartCoroutine(Scroll());
        }
    }

    // Update is called once per frame
    void UpdateText()
    {
        textDisplay.text = currentLoggedText[0];
        for (int i = 1; i<currentLoggedText.Length; i++)
        {
            textDisplay.text += "\n" + currentLoggedText[i];
        }
    }

    IEnumerator Scroll()
    {
        for(int s = 0; s<currentText.Length+1; s++)
        {
            currentLoggedText[current] = "<color=" + currentColor + ">" + currentText.Substring(0, s) + "</color>";
            UpdateText();
            yield return new WaitForSeconds(delay);
        }
        Next();
    }

    public void OnSelect()
    {
        StopAllCoroutines();
        if(current >= dialog.Length)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            currentLoggedText[current] = "<color="+currentColor+">"+currentText+"</color>";
            UpdateText();
            Next();
        }
    }
}
