using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public float xForce = 25f;
    public float yForce = 25f;
    [SerializeField] private Rigidbody2D rb;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            rb.velocity = new Vector2(xForce, yForce);
        }    
    }
}
