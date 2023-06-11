using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameSaveManager saveManager;

    public void Start()
    {
        saveManager.SaveGame();
    }

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
        saveManager.LoadGame();
        SceneManager.LoadScene(12, LoadSceneMode.Single);
    }
}
