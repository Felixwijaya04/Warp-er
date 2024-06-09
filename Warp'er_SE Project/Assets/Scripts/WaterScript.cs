using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WaterScript : MonoBehaviour
{
    public UI_Manager manager;
    private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sceneName = SceneManager.GetActiveScene().name;
            Invoke("restart", 0.2f);
        }
    }

    private void restart()
    {
        manager.changeScene(sceneName);
    }
}
