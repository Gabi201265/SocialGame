using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initSound : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource AudioSource;
    public AudioClip clip;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        AudioSource.PlayOneShot(clip);
        
        StartCoroutine(PlaySoundAndWait());
        
    }
    private IEnumerator PlaySoundAndWait()
    {
        AudioSource.PlayOneShot(clip);

        yield return new WaitForSecondsRealtime(6);
        AudioSource.Play();
        AudioSource.loop = true;
        // Suite du code ici
    }
}
