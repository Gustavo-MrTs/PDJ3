using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBlock : MonoBehaviour
{
    public GameObject Slider;
    private SliderProgression slider;

    private void Start()
    {
        slider = Slider.GetComponent<SliderProgression>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tag)
        {
            Debug.Log("Formas correspondentes :D");

            slider.IncreaseProgress();

        }

        else 
        {
            Debug.Log("Formas diferentes :(");
        
        }
    }
}
