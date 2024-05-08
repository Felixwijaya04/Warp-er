using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MovementSpeed = 10f;
    public float JumpPower = 13f;
    private float horizontal;
    public GameObject SwapWith;
    public Vector2 tempPosition;
    public GameObject PlayerPosition;
    private bool isFacingRight = true;
    private bool isDropping = false;
    public bool Swapped = false;
    private bool isJumping = false;
    [SerializeField] private Rigidbody2D rb;
    public GrabScript gs;


    public Animator animator;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.W) && isDropping == false && isJumping == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            isJumping = true;
        }
        // swap with object
        if (Input.GetKeyDown(KeyCode.E) && gs.isHoldingPendant == false)
        {
            swap();
            Swapped = true;
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
        /*Swapped = false;*/

        if(gs.justGrabBox == true)
        {
            // play grab animation
            Debug.Log("grab anim triggered");
            gs.justGrabBox = false;
            animator.SetBool("isGrabbing", true);
            Invoke("stopGrabAnim", 0.4f);
        }

        if(gs.isHolding == true)
        {
            MovementSpeed = 5f;
        }
        if(gs.isHolding == false)
        {
            MovementSpeed = 10f;
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
        /*tempPosition = PlayerPosition.transform.position;
        PlayerPosition.transform.position = SwapWith.transform.position;
        SwapWith.transform.position = tempPosition;*/
        PlayerPosition.transform.position = SwapWith.transform.position;
        gs.pendantGrab();
    }

    private void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
        
    }

    void stopGrabAnim()
    {
        animator.SetBool("isGrabbing", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
