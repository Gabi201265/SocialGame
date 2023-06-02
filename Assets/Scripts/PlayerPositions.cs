using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPositions : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
    }

    private void OnDestroy()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Vector3 playerPosition = playerTransform.position;

        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            Debug.Log(playerPosition);
            gameManager.SetPlayerCoordinates(currentSceneIndex, playerPosition);
        }
        else
        {
            Debug.LogError("Objet GameManager introuvable dans la scène.");
        }
    }
}
