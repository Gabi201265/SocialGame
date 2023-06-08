using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.U2D.Animation;
using UnityEngine.SceneManagement;

using TMPro;

public class CustomizeCharacterUiPanel : MonoBehaviour
{

    [Header("Body Part")]
    [SerializeField] GameObject body;
    [SerializeField] GameObject hair;
    [SerializeField] GameObject shirt;
    [SerializeField] GameObject pant;
    [SerializeField] GameObject cheek;

    [SerializeField] public SO_CharacterDescription characterDescription;

    [SerializeField] public SO_CharacterCompositionElement[] SO_SkinColorOptions;
    [SerializeField] public SO_CharacterCompositionElement[] SO_HairOptions;
    [SerializeField] public SO_CharacterCompositionElement[] SO_ShirtOptions;
    [SerializeField] public SO_CharacterCompositionElement[] SO_PantsOptions;

    [SerializeField] SpriteLibraryAsset cheekLibrary;
    int currSkinColorIndex;
    int currHairIndex;
    int currShirtIndex;
    int currPantsIndex;


    [SerializeField] TextMeshProUGUI SkinColorTextField; 
    [SerializeField] TextMeshProUGUI HairTextField; 
    [SerializeField] TextMeshProUGUI ShirtTextField; 
    [SerializeField] TextMeshProUGUI PantsTextField; 
    [SerializeField] TextMeshProUGUI CheekTextField; 

    SpriteRenderer bodySprite;
    SpriteRenderer hairSprite;
    SpriteRenderer shirtSprite;
    SpriteRenderer pantsSprite;
    SpriteRenderer cheekSprite;

    Image bodyImage;
    Image hairImage;
    Image shirtImage;
    Image pantsImage;
    Image cheekImage;

    SpriteResolver bodySR;

    Animator animator;
    int currDirectionIndex;
    Vector2 currDirection;

    Vector2[] directions = {
        new Vector2(0, -1),
        new Vector2(1, -1),
        new Vector2(1, 0),
        new Vector2(1, 1),
        new Vector2(0, 1),
        new Vector2(-1, 1),
        new Vector2(-1, 0),
        new Vector2(-1, -1)
    };


    SO_CharacterCompositionElement currSkinTone;
    SO_CharacterCompositionElement currHairColor;
    SO_CharacterCompositionElement currShirtColor;
    SO_CharacterCompositionElement currPantsColor;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        bodySprite = body.GetComponent<SpriteRenderer>() ;
        hairSprite = hair.GetComponent<SpriteRenderer>();
        shirtSprite = shirt.GetComponent<SpriteRenderer>();
        pantsSprite = pant.GetComponent<SpriteRenderer>();
        cheekSprite = cheek.GetComponent<SpriteRenderer>();


        bodyImage = body.GetComponent<Image>();
        hairImage = hair.GetComponent<Image>();
        shirtImage = shirt.GetComponent<Image>();
        pantsImage = pant.GetComponent<Image>();
        cheekImage = cheek.GetComponent<Image>();

        currDirectionIndex = 0;
        currDirection = directions[currDirectionIndex];

        currSkinTone = characterDescription.skinTone;
        currHairColor = characterDescription.hairColor;
        currShirtColor = characterDescription.shirtColor;
        currPantsColor = characterDescription.pantsColor;


        for(int i = 0; i < SO_SkinColorOptions.Length; i++)
            if(SO_SkinColorOptions[i] == characterDescription.skinTone)
                currSkinColorIndex = i;
        for(int i = 0; i < SO_HairOptions.Length; i++)
            if(SO_HairOptions[i] == characterDescription.hairColor)
                currHairIndex = i;
        for(int i = 0; i < SO_ShirtOptions.Length; i++)
            if(SO_ShirtOptions[i] == characterDescription.shirtColor)
                currShirtIndex = i;
        for(int i = 0; i < SO_PantsOptions.Length; i++)
            if(SO_PantsOptions[i] == characterDescription.pantsColor)
                currPantsIndex = i;


        

        ChangeCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacter();
    }


    void ChangeCharacter()
    {

        //body
        body.GetComponent<SpriteLibrary>().spriteLibraryAsset = characterDescription.skinTone.library;
        bodyImage.sprite = bodySprite.sprite;
        bodyImage.material = bodySprite.material;
        bodyImage.material.color = characterDescription.skinTone.color;
        SkinColorTextField.text = SO_SkinColorOptions[currSkinColorIndex].elementName;
        
        //hair
        hair.GetComponent<SpriteLibrary>().spriteLibraryAsset = characterDescription.hairColor.library;
        hairImage.sprite = hairSprite.sprite;
        hairImage.material = hairSprite.material;
        hairImage.material.color = characterDescription.hairColor.color;
        HairTextField.text = SO_HairOptions[currHairIndex].elementName;
        //shirt
        shirt.GetComponent<SpriteLibrary>().spriteLibraryAsset = characterDescription.shirtColor.library;
        shirtImage.sprite = shirtSprite.sprite;
        shirtImage.material = shirtSprite.material;
        shirtImage.material.color = characterDescription.shirtColor.color;
        ShirtTextField.text = SO_ShirtOptions[currShirtIndex].elementName;

        //pants
        pant.GetComponent<SpriteLibrary>().spriteLibraryAsset = characterDescription.pantsColor.library;
        pantsImage.sprite = pantsSprite.sprite;
        pantsImage.material = pantsSprite.material;
        pantsImage.material.color = characterDescription.pantsColor.color;
        PantsTextField.text = SO_PantsOptions[currPantsIndex].elementName;

        //cheek
        cheek.GetComponent<SpriteLibrary>().spriteLibraryAsset = cheekLibrary;
        cheekImage.sprite = cheekSprite.sprite;
        cheekImage.material = cheekSprite.material;
        cheekImage.material.color = cheekSprite.material.color;
        CheekTextField.text = characterDescription.sexe.ToString();
        cheek.SetActive(characterDescription.sexe == SO_CharacterDescription.Sexe.Female ? true : false);


    }

    public void RotateCW()
    {

        currDirectionIndex = (currDirectionIndex < directions.Length - 1) ? currDirectionIndex + 1 : 0;
        currDirection = directions[currDirectionIndex];
        animator.SetFloat("Horizontal", currDirection.x);
        animator.SetFloat("Vertical", currDirection.y);
    }
    
    public void RotateCCW()
    {

        currDirectionIndex = (currDirectionIndex == 0) ? directions.Length - 1 : currDirectionIndex - 1;
        currDirection = directions[currDirectionIndex];
        animator.SetFloat("Horizontal", currDirection.x);
        animator.SetFloat("Vertical", currDirection.y);
    }



    public void RightArrowSkinColor()
    {
        currSkinColorIndex = (currSkinColorIndex < SO_SkinColorOptions.Length - 1) ? currSkinColorIndex + 1 : 0;
        characterDescription.skinTone = SO_SkinColorOptions[currSkinColorIndex];
    }
    
    public void LeftArrowSkinColor()
    {
        currSkinColorIndex = (currSkinColorIndex == 0) ? SO_SkinColorOptions.Length - 1 : currSkinColorIndex - 1;
        characterDescription.skinTone = SO_SkinColorOptions[currSkinColorIndex];
    }

    public void RightArrowHair()
    {
        currHairIndex = (currHairIndex < SO_HairOptions.Length - 1) ? currHairIndex + 1 : 0;
        characterDescription.hairColor = SO_HairOptions[currHairIndex];
    }
    
    public void LeftArrowHair()
    {
        currHairIndex = (currHairIndex == 0) ? SO_HairOptions.Length - 1 : currHairIndex - 1;
        characterDescription.hairColor = SO_HairOptions[currHairIndex];
    }

    public void RightArrowShirt()
    {
        currShirtIndex = (currShirtIndex < SO_ShirtOptions.Length - 1) ? currShirtIndex + 1 : 0;
        characterDescription.shirtColor = SO_ShirtOptions[currShirtIndex];
    }
    
    public void LeftArrowShirt()
    {
        currShirtIndex = (currShirtIndex == 0) ? SO_ShirtOptions.Length - 1 : currShirtIndex - 1;
        characterDescription.shirtColor = SO_ShirtOptions[currShirtIndex];
    }

    public void RightArrowPants()
    {
        currPantsIndex = (currPantsIndex < SO_PantsOptions.Length - 1) ? currPantsIndex + 1 : 0;
        characterDescription.pantsColor = SO_PantsOptions[currPantsIndex];
    }
    
    public void LeftArrowPants()
    {
        currPantsIndex = (currPantsIndex == 0) ? SO_PantsOptions.Length - 1 : currPantsIndex - 1;
        characterDescription.pantsColor = SO_PantsOptions[currPantsIndex];
    }


    public void ArrowSexe()
    {
        characterDescription.sexe = characterDescription.sexe == SO_CharacterDescription.Sexe.Male ? SO_CharacterDescription.Sexe.Female : SO_CharacterDescription.Sexe.Male;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
}
