using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Vector3[] playerCoordinates;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializePlayerCoordinates();
    }

    public void SetPlayerCoordinates(int sceneIndex, Vector3 coordinates)
    {
        if (sceneIndex >= 0 && sceneIndex < playerCoordinates.Length)
        {
            playerCoordinates[sceneIndex] = coordinates;
        }
        else
        {
            Debug.LogError("Index de scène invalide : " + sceneIndex);
        }
    }

    public Vector3 GetPlayerCoordinates(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < playerCoordinates.Length)
        {
            return playerCoordinates[sceneIndex];
        }
        else
        {
            Debug.LogError("Index de scène invalide : " + sceneIndex);
            return Vector3.zero;
        }
    }

    private void InitializePlayerCoordinates()
    {
        int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        playerCoordinates = new Vector3[sceneCount];

        playerCoordinates[0] = new Vector3(0, 0, 0);
        playerCoordinates[1] = new Vector3(7.95f, 1.9f, 0);
        playerCoordinates[2] = new Vector3(45.74f, -56.69f, 0);
        playerCoordinates[3] = new Vector3(0, 0, 0);
        playerCoordinates[4] = new Vector3(-0.55f, -4.82f, 0);
        playerCoordinates[5] = new Vector3(-5f, -4.6f, 0);
        playerCoordinates[6] = new Vector3(-8.81f, -3.79f, 0);
        playerCoordinates[7] = new Vector3(7f, -4f, 0);
        playerCoordinates[8] = new Vector3(-7f, -4f, 0);
        playerCoordinates[9] = new Vector3(-7f, -4f, 0);
        playerCoordinates[10] = new Vector3(8.4f, -4.21f, 0);
        playerCoordinates[11] = new Vector3(7f, -5.27f, 0);
        //for (int i = 0; i < sceneCount; i++)
        //{
        //    playerCoordinates[i] = Vector3.zero;
        //}
    }
}
