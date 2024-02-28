using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float force;
    private Vector2 direction;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        // code buat throw obj
        if (Input.GetMouseButtonDown(0) && GrabScript.isHolding == true)
        {
            transform.parent = null;
            if (GetComponent<Rigidbody2D>())
            {
                GetComponent<Rigidbody2D>().simulated = true;
            }
            rb.velocity = new Vector2(direction.x * force, direction.y * force);
            GrabScript.isHolding = false;
        }
    }
}
