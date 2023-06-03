using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AudioPlayer : MonoBehaviour
{
    public Tilemap tilemap;

    public AudioClip[] footstepsGround;
    public AudioClip[] footstepsGrass;
    public AudioClip[] footstepsStone;
    public float footstepDelay = 0.5f;
    private ArrayList[] groundtileNames;
    private string[] grasstileNames;
    private string[] stonetileNames;

    public AudioClip mainTheme;

    private AudioSource audioSource;
    private float nextFootstepTime = 0.0f;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
         /*groundtileNames = new ArrayList()=  "Tileset_17_MV_36", "Tileset_17_MV_47", "Tileset_17_MV_21", "Tileset_17_MV_49", "Tileset_17_MV_112"];
         grasstileNames = new string[] { "Tileset_17_MV_16", "Tileset_17_MV_51", "Tileset_17_MV_53", "Tileset_17_MV_22" , "Tileset_1_MV_207", "Tileset_1_MV_208" };
         stonetileNames = new string[] { "Tileset_16_MV_31", "Tileset_16_MV_15", "Tileset_16_MV_32", "Tileset_16_MV_16" };
*/         


    }

    private void Update()
    {

        // Vérifie si le personnage se déplace
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            Vector3Int cellPosition = tilemap.WorldToCell(transform.position);
            TileBase tile = tilemap.GetTile(cellPosition);
          /*  if (groundtileNames.Cont)
            {

            }*/
                // Vérifie si c'est le moment de jouer un son de pas
                if (Time.time >= nextFootstepTime)
            {
                // Choisis un son de pas aléatoire dans la liste
                int index = Random.Range(0, footstepsGround.Length);
                AudioClip footstepSound = footstepsGround[index];

                // Joue le son de pas
                audioSource.PlayOneShot(footstepSound);

                // Définit le temps du prochain pas
                nextFootstepTime = Time.time + footstepDelay;
            }
        }
    }
}
