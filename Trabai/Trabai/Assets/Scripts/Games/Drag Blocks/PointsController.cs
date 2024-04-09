using UnityEngine;
using TMPro;

public class PointsController : MonoBehaviour
{
    private int pontos;
    public int Pontos
    {
        get { return pontos; }
        set
        {
            pontos = value;
            AtualizarTextoPontos(); // Chama o m�todo para atualizar o texto sempre que os pontos mudarem
        }
    }

    private TextMeshProUGUI textoPontos;

    // Start is called before the first frame update
    void Start()
    {
        // Obt�m o componente TextMeshProUGUI associado ao GameObject
        textoPontos = GetComponent<TextMeshProUGUI>();

        // Define o texto inicial dos pontos
        AtualizarTextoPontos();
    }

    // M�todo para atualizar o texto dos pontos
    void AtualizarTextoPontos()
    {
        // Define o texto do componente TextMeshProUGUI para mostrar a quantidade de pontos
        textoPontos.text = "Pontos: " + pontos.ToString();
    }
}
