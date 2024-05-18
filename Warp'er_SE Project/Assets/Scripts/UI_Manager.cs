using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void playTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void pause()
    {
        Time.timeScale = 0f;
    }
    public void resume()
    {
        Time.timeScale = 1f;
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
