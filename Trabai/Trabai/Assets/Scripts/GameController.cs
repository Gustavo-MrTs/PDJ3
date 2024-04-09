using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject mouseClick; 

    void Update()
    {
    
        if (Input.GetMouseButtonDown(0))
        {
           
            AudioSource audioSource = mouseClick.GetComponent<AudioSource>();
            if (audioSource != null)
            {
             
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Componente de �udio n�o encontrado no GameObject mouseClick.");
            }
        }
    }
}
