using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    [Header("GameObject Ref")]
    public GameObject PauseMenu;
    public GameObject FinishMenu;

    public static int LevelStage = 0;
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

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && PauseMenu.activeSelf == false)
        {
            PauseMenu.gameObject.SetActive(true);
            pause();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && PauseMenu.activeSelf == true)
        {
            PauseMenu.gameObject.SetActive(false);
            resume();
        }
    }
    public void playTutorial()
    {
        SceneManager.LoadScene("Tutorial");
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

    public void LevelFinish()
    {
        Time.timeScale = 0f;
        Input.ResetInputAxes();
        FinishMenu.gameObject.SetActive(true);
        LevelStage++;
        //Debug.Log(LevelStage);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LevelFinish();
        }
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
