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
        if (collision.CompareTag("Pendant"))
        {
            _isActivate = true;
        }
        if (collision.CompareTag("Wooden Crate"))
        {
            _isActivate = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isPlayer = false;  
        }
        if (collision.CompareTag("Pendant"))
        {
            _isActivate = false;
        }
        if (collision.CompareTag("Wooden Crate"))
        {
            _isActivate = false;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pendant"))
        {
            _isActivate = true;
        }
        if (collision.gameObject.CompareTag("Wooden Crate"))
        {
            _isActivate = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pendant"))
        {
            _isActivate = false;
        }
        if (collision.gameObject.CompareTag("Wooden Crate"))
        {
            _isActivate = false;
        }
    }*/
}
