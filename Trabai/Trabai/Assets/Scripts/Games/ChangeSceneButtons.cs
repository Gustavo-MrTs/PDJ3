using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButtons : MonoBehaviour
{
    public int nextSceneIndex;

    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void LoadNextGame()
    {
        SceneManager.LoadScene(nextSceneIndex);

    }


}
