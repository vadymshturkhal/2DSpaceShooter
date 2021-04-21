using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScenes : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
}
