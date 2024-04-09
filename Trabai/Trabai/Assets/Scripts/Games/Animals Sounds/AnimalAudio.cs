using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAudio : MonoBehaviour
{
    public AnimalAudio prox;
    public AnimalAudio ant;
    public AudioSource audio;

    public AnimalAudio(AudioSource audio)
    {
        this.audio = audio;



    }

    public AnimalAudio()
    {



    }

    public void Play() 
    { 
    audio.Play();
    
    }



}
