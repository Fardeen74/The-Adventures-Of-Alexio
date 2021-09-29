using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundFX, OST;

    public AudioClip[] themeSongs;
    void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        if(!OST.playOnAwake)
        {
            OST.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            OST.Play();
        }
    }

    void Update()
    {
        if (!OST.isPlaying)
        {
            OST.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            OST.Play();
        }

    }

    public void PlaySoundFX(AudioClip clip)
    {
        soundFX.clip = clip;
        //soundFX.volume = Random.Range(.3f, .5f);
        //soundFX.pitch = Random.Range(.8f, 1f);
        soundFX.Play();
    }
}
