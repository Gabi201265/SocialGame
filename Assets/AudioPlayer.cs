using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AudioPlayer : MonoBehaviour
{
    public Tilemap tilemap;
    public Boolean isStone;
    public Boolean isGround;
    public Boolean isGrass;
    public AudioClip[] footStepCollection;
    public AudioClip[] footstepsGround;
    public AudioClip[] footstepsGrass;
    public AudioClip[] footstepsStone;
    public float footstepDelay = 1;
    private string zoneWalking;

    public AudioSource audioSource;
    private float LastTimeFootstep = 0;
    
    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();

    }
    
    private void Update()
    {
        audioSource.loop = true;

        
        if (Time.time >= LastTimeFootstep + footstepDelay && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            int index = UnityEngine.Random.Range(0, footstepsStone.Length - 1);
            AudioClip footstepSound = footStepCollection[index];
            audioSource.PlayOneShot(footstepSound, 1f);
            
            LastTimeFootstep = Time.time;
           
        }
        
    }
}
