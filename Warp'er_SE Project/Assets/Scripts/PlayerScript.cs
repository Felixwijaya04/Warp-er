using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Settings")]
    public float MovementSpeed = 10f;
    public float JumpPower = 13f;
    public AudioClip walk;
    
    [Header("Player Info")]
    private float horizontal;
    public GameObject SwapWith;
    public Vector2 tempPosition;
    public GameObject PlayerPosition;

    private bool isFacingRight = true;
    private bool isDropping = false;
    public bool Swapped = false;
    private bool isJumping = false;
    [SerializeField] private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool Is_walksound = false;
    [SerializeField] public float FallingGravity;

    [Header("Script Reference")]
    public GrabScript gs;
    public AudioManager audioManager;
    public Animator animator;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            if (horizontal != 0 && isGrounded == true && Is_walksound == false)
            {
                StartCoroutine("walkSound");
                
            }

            if (Input.GetKeyDown(KeyCode.W) && isDropping == false && isJumping == false)
            {
                audioManager.PlaySfx(audioManager.jump);
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);
                isJumping = true;
                isGrounded = false;
            }
            // swap with object
            if (Input.GetKeyDown(KeyCode.E) && gs.isHoldingPendant == false)
            {
                swap();
                Swapped = true;
            }
            if (mousePos.x > transform.position.x && !isFacingRight && Time.timeScale != 0f)
            {
                if (!UI_Manager.instance.IsPointerOverUIObject())
                {
                    flip();
                }
            }
            else if (mousePos.x < transform.position.x && isFacingRight && Time.timeScale != 0f)
            {
                if (!UI_Manager.instance.IsPointerOverUIObject())
                {
                    flip();
                }
            }
            // drop down in platform
            if (Input.GetKey(KeyCode.S))
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

            if (gs.justGrabBox == true)
            {
                // play grab animation
                Debug.Log("grab anim triggered");
                gs.justGrabBox = false;
                animator.SetBool("isGrabbing", true);
                Invoke("stopGrabAnim", 0.4f);
            }

            if (gs.isHolding == true)
            {
                MovementSpeed = 5f;
            }
            if (gs.isHolding == false)
            {
                MovementSpeed = 10f;
            }

            if (rb.velocity.y < 0)
            {
                //rb.gravityScale = FallingGravity;
                rb.velocity = new Vector2(rb.velocity.x/4,rb.velocity.y * FallingGravity);
            }
            else
            {
                rb.gravityScale = 1f;
            }
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
            isGrounded = true;
        }
        if(other.gameObject.CompareTag("Wooden Crate"))
        {
            isJumping = false;
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            isJumping = false;
        }
        if (other.gameObject.CompareTag("SwappableObject"))
        {
            isJumping = false;
        }
    }

    IEnumerator walkSound()
    {
        Is_walksound = true;
        audioManager.PlaySfx(audioManager.walk);
        yield return new WaitForSeconds(0.149f);
        Is_walksound = false;
    }
}
