using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsAudioPlayer : MonoBehaviour
{
    public List<AudioSource> audios;
    public AnimalAudio sent;

    private int availableAudios;

    private AnimalAudio currentAudio;

    // Start is called before the first frame update
    void Awake()
    {
        sent = new AnimalAudio();
        sent.prox = sent;
        sent.ant = sent;

        AnimalAudio at = sent;

        for (int i = 0; i < audios.Count; i++)
        {
            at.prox = new AnimalAudio(audios[i]);
            at.prox.ant = at;
            at = at.prox;
        }


        at.prox = sent;
        sent.ant = at;

        availableAudios = audios.Count;
    }

    public void PlayRandomAudio()
    {
        int r = UnityEngine.Random.Range(0, availableAudios) + 1;
        availableAudios--;
        

        PlayAndRemoveByPosition(r);
    }

    private void PlayAndRemoveByPosition(int position)
    {
        AnimalAudio at = sent;
        int i;
        for (i = 1, at = sent.prox; i != position /*|| at != sent*/; i++, at = at.prox);

        at.Play();
        at.prox.ant = at.ant;
        at.ant.prox = at.prox;
        at.ant = null;
        at.prox = null;

        currentAudio = at;

    }

    public void ReplayLastAudio()
    {
        currentAudio.Play();

    }
}
