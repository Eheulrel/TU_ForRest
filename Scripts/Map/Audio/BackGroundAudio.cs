using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour
{
    public AudioClip[] audio;

    AudioSource aSource;

    // Start is called before the first frame update
    void Awake()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = audio[0];      
    }

    void Update()
    {
        if (BackGroundd.mapnum.Equals(0))
        {
            aSource.clip = audio[0];
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }           
        else if (BackGroundd.mapnum.Equals(1))
        {
            aSource.clip = audio[1];
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }        
        else if (BackGroundd.mapnum.Equals(2))
        {
            aSource.clip = audio[2];
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (BackGroundd.mapnum.Equals(3))
        {
            aSource.clip = audio[3];
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (BackGroundd.mapnum.Equals(4))
        {
            aSource.clip = audio[4];
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
        else if (BackGroundd.mapnum.Equals(5))
        {
            aSource.clip = audio[5];
            if (!aSource.isPlaying)
            {
                aSource.Play();
            }
        }
    }
}
