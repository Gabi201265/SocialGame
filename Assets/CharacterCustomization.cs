using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.U2D.Animation;

public class CharacterCustomization : MonoBehaviour
{
    enum Body { normal };
    enum Hair { buzz };
    enum Shirt { normal };
    enum Pant { normal };

    [Header("Custom Character")]
    [SerializeField] bool isGirl = false;

    [SerializeField] Body body;
    [SerializeField] Hair hair;
    [SerializeField] Shirt shirt;
    [SerializeField] Pant pant;


    [Header("Skin Tones")]
    [SerializeField] List<Color> m_skinTone;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
