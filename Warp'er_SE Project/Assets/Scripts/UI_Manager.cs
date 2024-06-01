using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Awake()
    {
        // Ensure there's only one instance of UIManager
        if (instance == null)
        {
            instance = this;
            
        }
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
        Input.ResetInputAxes();
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

    public bool IsPointerOverUIObject()
    {
        if(EventSystem.current == null) return false;

        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
