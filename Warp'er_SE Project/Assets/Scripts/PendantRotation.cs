using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendantRotation : MonoBehaviour
{
    public bool canRotate = false;
    public float rotSpeed;
    public PlayerScript ps;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(0,0,rotSpeed * Time.deltaTime);
        }
        if(ps.Swapped == true)
        {
            Debug.Log("swapped detected");
            rb.isKinematic = false;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
            ps.Swapped = false;
        }
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        canRotate = false;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        rb.freezeRotation = true;
    }*/
}
