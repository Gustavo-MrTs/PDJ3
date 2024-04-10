using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagesController : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject levelComplete;

    public int currentStage = 0;


    // Start is called before the first frame update
    void Awake()
    {
        levels[0].SetActive(true);

        for(int i = 1; i < levels.Length; i++)
        {
            levels[i].SetActive(false);


        }

        levelComplete.SetActive(false);


    }

   public void ProgressStage()
    {
        currentStage++;

        for(int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);

            if(i == currentStage) levels[i].SetActive(true);
        }

        if(currentStage == levels.Length) levelComplete.SetActive(true);

    }
}
