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
    [SerializeField] private Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            swap();
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
}
