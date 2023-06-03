using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == sceneBuildIndex)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;

            GameManager gameManager = FindObjectOfType<GameManager>();
            Vector3 playerPosition = gameManager.GetPlayerCoordinates(sceneBuildIndex);

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = playerPosition;
        }
    }
}

