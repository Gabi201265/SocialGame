using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerStone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("aaaa");
        if (collision.name == "Player")
        {

            collision.gameObject.GetComponent<AudioPlayer>().footStepCollection = collision.gameObject.GetComponent<AudioPlayer>().footstepsStone;
        }

    }
}
    

