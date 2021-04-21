using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("_MainMenu");
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("_MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
            Application.OpenURL(webplayerQuitURL);
        #else
            Application.Quit();
        #endif
    }
}
