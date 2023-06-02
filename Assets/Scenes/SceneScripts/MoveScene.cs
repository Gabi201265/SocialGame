using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public Animator transition;
    public int sceneBuildIndex;
    // Start is called before the first frame update
    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Entered");

        if (other.tag == "Player")
        {
            
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
