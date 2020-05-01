using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    public AudioClip zap;
    public AudioClip hit;
    public AudioClip fire;
    public AudioClip arcane;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        hit = Resources.Load<AudioClip>("Impact");
        fire = Resources.Load<AudioClip>("fire");
        zap = Resources.Load<AudioClip>("zap");
        arcane = Resources.Load<AudioClip>("arcane");

        source = GetComponent<AudioSource>();
    }
    public void PlaySound (string sound)
    {
        if(sound == "hit")
        {
            source.PlayOneShot(hit);
        }
        if (sound == "fire")
        {
            source.PlayOneShot(fire);
        }
        if (sound == "zap")
        {
            source.PlayOneShot(zap);
        }
        if (sound == "arcane")
        {
            source.PlayOneShot(arcane);
        }
    }

    
}
