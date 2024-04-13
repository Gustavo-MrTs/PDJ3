using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject configUI;
    public GameObject creditsUI;
    public GameObject musicaDeFundo;
    public GameObject somMouseClick;
    public GameObject gamesUI;

    public List<GameObject> notasPiano;
    private List<AudioSource> audios;


    private void Start()
    {
        audios = new List<AudioSource>();

        for (int i = 0; i < notasPiano.Count; i++)
        {
            audios.Add(notasPiano[i].GetComponent<AudioSource>());
        }
    }

    public void PlayGame1()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame2()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayGame3()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayGame4()
    {
        SceneManager.LoadScene(5);
    }

    public void PlayGame5()
    {
        SceneManager.LoadScene(5);
    }

    public void OpenGamesUI()
    {
        configUI.SetActive(false);
        creditsUI.SetActive(false);
        gamesUI.SetActive(true);

    }

    // Call this method when the open button is clicked
    public void OpenConfigUI()
    {
        creditsUI.SetActive(false);
        gamesUI.SetActive(false);
        configUI.SetActive(true); // Show the config UI
    }

    // Call this method when the close button is clicked
    public void CloseConfigUI()
    {
        configUI.SetActive(false); // Hide the config UI
    }

    public void OpenCreditsUI()
    {
        configUI.SetActive(false); // Hide the config UI
        gamesUI.SetActive(false);
        creditsUI.SetActive(true);

    }

    public void CloseCreditsUI()
    {
        creditsUI.SetActive(false);

    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MuteMusic()
    {
        musicaDeFundo.GetComponent<AudioSource>().mute = !musicaDeFundo.GetComponent<AudioSource>().mute;
    }

    public void MuteMouseClick()
    {

        somMouseClick.GetComponent<AudioSource>().mute = !somMouseClick.GetComponent<AudioSource>().mute;
    }

    public void PlayPiano(int index)
    {
        audios[index].Play();

    }
}
