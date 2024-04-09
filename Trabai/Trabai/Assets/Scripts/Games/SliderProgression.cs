using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderProgression : MonoBehaviour
{
    public GameObject fill; // Referência à imagem de preenchimento
    public int sucessesRequired; // Número total de sucessos necessários
    private int currentSucesses = 0; // Número atual de sucessos

    // Método para aumentar a barra de progressão
    public void IncreaseProgress()
    {
        // Incrementa o número atual de sucessos
        currentSucesses++;

        // Calcula a escala horizontal da barra de preenchimento
        float scaleX = (float)currentSucesses / sucessesRequired;

        // Limita o valor máximo da escala a 1
        scaleX = Mathf.Clamp01(scaleX);

        // Atualiza a escala da imagem de preenchimento
        fill.transform.localScale = new Vector3(scaleX, 1f, 1f);
    }
}
