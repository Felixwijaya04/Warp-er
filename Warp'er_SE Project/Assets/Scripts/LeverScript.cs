using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject prompts;
    public bool _isPlayer = false;
    public bool _isActivate = false;

    // Update is called once per frame
    void Update()
    {
        if (_isPlayer == true)
        {
            prompts.SetActive(true);
        }
        if (_isPlayer == false)
        {
            prompts.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayer = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayer = false;  
        }
    }
}
