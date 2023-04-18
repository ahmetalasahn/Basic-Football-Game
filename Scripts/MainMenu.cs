using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void instagramOpen(string link)
    {
        Application.OpenURL(link);
    }
}
