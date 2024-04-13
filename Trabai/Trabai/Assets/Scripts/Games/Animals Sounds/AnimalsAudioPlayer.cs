using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnimalsAudioPlayer : MonoBehaviour
{
    public List<AudioSource> audios;
    public AnimalStage sent;

    public int availableAudios;

    public GameObject levelComplete;

    private AnimalStage currentAudio;

    private Button[] buttons;


    // Start is called before the first frame update
    void Awake()
    {
        /*  sent = new AnimalStage();
          sent.prox = sent;
          sent.ant = sent;

          AnimalStage at = sent;

          for (int i = 0; i < audios.Count; i++)
          {
              at.prox = new AnimalStage(audios[i]);
              at.prox.ant = at;
              at = at.prox;
          }


          at.prox = sent;
          sent.ant = at;

          availableAudios = audios.Count;
        */




        // Encontra todos os botões na cena
         buttons = FindObjectsOfType<Button>();

        // Itera sobre todos os botões encontrados
        foreach (Button but in buttons)
        {
            // Adiciona um listener de evento ao botão para o evento de clique
            but.onClick.AddListener(() => VerifyButtonTag(but));
        }

        PlayRandomAudio();
    }

    public void PlayRandomAudio()
    {
        int r = UnityEngine.Random.Range(0, availableAudios) + 1;
        availableAudios--;


        if (availableAudios >= 0) PlayAndRemoveByPosition(r);

        else
        {
            for (int i = 0; i < buttons.Length; i++) buttons[i].gameObject.SetActive(false);
            

            levelComplete.SetActive(true);
        }



    }

    private void PlayAndRemoveByPosition(int position)
    {
        AnimalStage at = sent;
        int i;
        for (i = 1, at = sent.prox; i != position /*|| at != sent*/; i++, at = at.prox);
        at.Play();
        at.ActiveStage();
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

    private void VerifyButtonTag(Button botao)
    {
        if (botao.CompareTag("Block"))
        {
           PlayRandomAudio();
        }
        else if (botao.CompareTag("Block2"))
        {
            Debug.Log("Errou D:");
        }
    }


}
