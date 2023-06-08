using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDescription", menuName = "SocialGame/CharacterDescription", order = 1)]
public class SO_CharacterDescription : ScriptableObject
{
    public enum Sexe { Male, Female };
    public string characterName;
    public int age;
    public Sexe sexe;
    public SO_CharacterCompositionElement skinTone;
    public SO_CharacterCompositionElement hairColor;
    public SO_CharacterCompositionElement shirtColor;
    public SO_CharacterCompositionElement pantsColor;

}
