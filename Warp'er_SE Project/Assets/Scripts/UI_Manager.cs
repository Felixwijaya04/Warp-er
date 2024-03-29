using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public void playTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void loadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
}
