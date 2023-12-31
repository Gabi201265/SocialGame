using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.U2D.Animation;

public class CharacterCustomization : MonoBehaviour
{

    [Header("Body Part")]

    [SerializeField] GameObject body;
    [SerializeField] GameObject hair;
    [SerializeField] GameObject shirt;
    [SerializeField] GameObject pant;
    [SerializeField] GameObject cheek;

    [Header("Character Description")]

    [SerializeField] public SO_CharacterDescription characterDescription;

    [SerializeField] GameSaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager.LoadGame();
        ChangeCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacter();
    }


    void ChangeCharacter()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //player.GetComponent<SO_CharacterDescription>().
        body.GetComponent<SpriteRenderer>().material.color = characterDescription.skinTone.color;
        hair.GetComponent<SpriteRenderer>().material.color = characterDescription.hairColor.color;
        shirt.GetComponent<SpriteRenderer>().material.color = characterDescription.shirtColor.color;
        pant.GetComponent<SpriteRenderer>().material.color = characterDescription.pantsColor.color;
        cheek.SetActive(characterDescription.sexe == SO_CharacterDescription.Sexe.Female ? true : false);

    }
}
