using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float JumpPower = 8f;
    private float horizontal;
    public GameObject SwapWith;
    public Vector2 tempPosition;
    public GameObject PlayerPosition;
    private bool isFacingRight = true;
    private bool isDropping = false;
    public static bool SwapQuota = true;
    [SerializeField] private Rigidbody2D rb;
   
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.W) && isDropping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }
        // swap with object
        if (Input.GetKeyDown(KeyCode.E))
        {
            swap();
        }
        if (mousePos.x > transform.position.x && !isFacingRight)
        {
            flip();
        }
        else if (mousePos.x < transform.position.x && isFacingRight)
        {
            flip();
        }
        // drop down in platform
        if(Input.GetKey(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(8, 7, true);
            isDropping = true;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 7, false);
            isDropping = false;
        }
    }

    private void FixedUpdate()
    {
        walking(MovementSpeed);
    }
    void walking(float speed)
    {
        rb.velocity = new Vector2(speed*horizontal,rb.velocity.y);
    }

    void swap()
    {
        tempPosition = PlayerPosition.transform.position;
        PlayerPosition.transform.position = SwapWith.transform.position;
        SwapWith.transform.position = tempPosition;
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
