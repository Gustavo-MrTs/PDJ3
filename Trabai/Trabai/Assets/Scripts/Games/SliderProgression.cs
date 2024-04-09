using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderProgression : MonoBehaviour
{
    public GameObject fill; // Refer�ncia � imagem de preenchimento
    public int sucessesRequired; // N�mero total de sucessos necess�rios
    private int currentSucesses = 0; // N�mero atual de sucessos

    // M�todo para aumentar a barra de progress�o
    public void IncreaseProgress()
    {
        // Incrementa o n�mero atual de sucessos
        currentSucesses++;

        // Calcula a escala horizontal da barra de preenchimento
        float scaleX = (float)currentSucesses / sucessesRequired;

        // Limita o valor m�ximo da escala a 1
        scaleX = Mathf.Clamp01(scaleX);

        // Atualiza a escala da imagem de preenchimento
        fill.transform.localScale = new Vector3(scaleX, 1f, 1f);
    }
}
