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

    private void Update()
    {
        //Debug.Log("coo :"+playerCoordinates[1]);
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

        for (int i = 0; i < sceneCount; i++)
        {
            playerCoordinates[i] = Vector3.zero;
        }
    }
}
