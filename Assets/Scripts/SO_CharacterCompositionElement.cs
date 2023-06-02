using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "ElementName", menuName = "SocialGame/CharacterCompositionElement", order = 2)]
public class SO_CharacterCompositionElement : ScriptableObject
{
    enum Type { Body, Hair, Shirt, Pants}
    public SpriteLibraryAsset library;
    public string elementName;
    [SerializeField] Type type;
    public Color color;
}
