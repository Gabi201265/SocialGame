using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerGrass : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.name == "Player")
        {

            collision.gameObject.GetComponent<AudioPlayer>().footStepCollection = collision.gameObject.GetComponent<AudioPlayer>().footstepsGrass;
        }

    }
}
    

