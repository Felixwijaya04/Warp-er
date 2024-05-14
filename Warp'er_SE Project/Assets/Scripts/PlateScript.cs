using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    public bool _isActivate = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isActivate = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isActivate = false;
    }
}
