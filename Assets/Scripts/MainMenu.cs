using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Exterior2.0", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void custom()
    {
        SceneManager.LoadScene(12, LoadSceneMode.Single);
    }
}
