using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button mainMenuButton, creditsMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void NewGame()
    {
        Save.LoadFirstCheckpoint();
    }

    public void ContinueGame()
    {
        //Debug.Log("Not implemented yet");
        Save.LoadCheckpoint();
    }

    public void OpenCredits()
    {
        creditsMenuButton = GameObject.FindGameObjectWithTag("CreditsMenu").GetComponent<Button>();
        creditsMenuButton.Select();
    }

    public void CloseCredits()
    {
        mainMenuButton = GameObject.FindGameObjectWithTag("MainMenu").GetComponent<Button>();
        mainMenuButton.Select();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
