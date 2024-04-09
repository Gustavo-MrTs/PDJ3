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

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Call this method when the open button is clicked
    public void OpenConfigUI()
    {
        creditsUI.SetActive(false);
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
