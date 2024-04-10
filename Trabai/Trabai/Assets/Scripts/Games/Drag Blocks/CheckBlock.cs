using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    public GameObject Slider;
    private SliderProgression slider;
    public GameObject stageManager;

    private StagesController stagesController;

    private void Start()
    {
        slider = Slider.GetComponent<SliderProgression>();
        stagesController = stageManager.GetComponent<StagesController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tag)
        {
            Debug.Log("Formas correspondentes :D");

            slider.IncreaseProgress();

            stagesController.ProgressStage();
        }

        else 
        {
            Debug.Log("Formas diferentes :(");
        
        }
    }
}
