using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Exterior2.0");
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
