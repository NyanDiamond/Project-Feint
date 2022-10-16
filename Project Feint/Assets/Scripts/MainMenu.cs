using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Prototype Level");
    }

    public void ContinueGame()
    {
        Debug.Log("Not implemented yet");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}