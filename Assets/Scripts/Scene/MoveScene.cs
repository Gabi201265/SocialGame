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
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                Vector3 playerPosition = other.transform.position;

                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                Debug.Log(playerPosition);
                gameManager.SetPlayerCoordinates(currentSceneIndex, playerPosition);
            }
            else
            {
                Debug.LogError("Objet GameManager introuvable dans la scène.");
            }

            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
