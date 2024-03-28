using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] float force;
    private Vector2 direction;
    public GrabScript gs;
    void Update()
    {
        // jika player sedang memegang pendant dan paket maka pendant yang akan dilempar, paket tdk bs dilempar
        // maka player hanya bisa melempar paket jika sedang tidak memegang pendant
        if (gs.isHoldingPendant == false && gs.isHolding == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            // code buat throw obj
            if (Input.GetMouseButtonDown(0))
            {
                transform.parent = null;
                if (GetComponent<Rigidbody2D>())
                {
                    GetComponent<Rigidbody2D>().simulated = true;
                }
                rb.velocity = new Vector2(direction.x * force, direction.y * force);
                gs.isHolding = false;
            }
        }
        
    }

}
