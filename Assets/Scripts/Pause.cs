using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pauseMenuUI;
    private bool isPaused = false;
    public ManageDay manageDayScript;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Debug.Log("Avant le set active");
                pauseMenuUI.SetActive(true);
                Debug.Log("Apres le set active");
                isPaused = true;
                Time.timeScale = 0f;
            }
            
            isPaused = !isPaused;
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        manageDayScript.setNbDay(0);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
