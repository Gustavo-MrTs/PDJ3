using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalStage : MonoBehaviour
{
    public AnimalStage prox;
    public AnimalStage ant;
    public AudioSource audio;

    public Image correctAnswer;

    public Image[] wrongAnswers;

    public Image BaseAnimalSprite;

    public Image NewAnimalSprite;

    public GameObject[] buttonBackground;

    private List<int> allowedNumbersButtons = new List<int>();
    private List<int> allowedNumbersWrongAnswersSprites = new List<int>();

    private void GenerateListInts()
    {
        for(int i = 0; i < buttonBackground.Length; i++)
        {
            allowedNumbersButtons.Add(i);
        }

        for (int i = 0; i < wrongAnswers.Length; i++)
        {
            allowedNumbersWrongAnswersSprites.Add(i);
        }


    }




    public AnimalStage(AudioSource audio)
    {
        this.audio = audio;



    }

    public AnimalStage()
    {



    }

    public void Play() 
    { 
    audio.Play();
    
    }

       public void ActiveStage()
    {
        GenerateListInts();

        BaseAnimalSprite.sprite = NewAnimalSprite.sprite;

        int r = GenerateRandomNumberAndRemove(allowedNumbersButtons);

        int s;

        buttonBackground[r].GetComponentInChildren<Image>().sprite = correctAnswer.sprite;
        buttonBackground[r].transform.parent.gameObject.tag = "Block";

        while (allowedNumbersButtons.Count > 0)
        {
            r = GenerateRandomNumberAndRemove(allowedNumbersButtons);
            buttonBackground[r].transform.parent.gameObject.tag = "Block2";

            s = GenerateRandomNumberAndRemove(allowedNumbersWrongAnswersSprites);
            buttonBackground[r].GetComponentInChildren<Image>().sprite = wrongAnswers[s].sprite;

        }


    }

    private int GenerateRandomNumberAndRemove(List<int> list)
    {
        int randomIndex = Random.Range(0, list.Count);

        int randomNumber = list[randomIndex];

        list.Remove(randomNumber);

        return randomNumber;
    }



}
