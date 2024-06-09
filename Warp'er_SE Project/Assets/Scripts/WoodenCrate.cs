using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : MonoBehaviour
{
    private Rigidbody2D rb;
    private FixedJoint2D joint;

    private void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the wooden crate collides with the moving platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            // Check if the wooden crate already has a FixedJoint2D
            joint = GetComponent<FixedJoint2D>();
            if (joint == null)
            {
                // If not, add a FixedJoint2D to the wooden crate
                joint = gameObject.AddComponent<FixedJoint2D>();
            }

            // Attach the wooden crate to the moving platform
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the wooden crate is no longer in contact with the moving platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            // If the wooden crate has a FixedJoint2D, destroy it
            if (joint != null)
            {
                Destroy(joint);
            }
        }
    }
}
