using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    private float vertical;
    public float speed;
    private bool isLadder;
    private bool isClimbing;
    public AudioManager audioManager;
    private bool is_climbSound = false;

    [SerializeField] private Rigidbody2D rb;

    // Update is called once per frame
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, speed * vertical);
            if(is_climbSound == false && rb.velocity.y !=0 )
            {
                StartCoroutine("ladderSound");
            }
            
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
    IEnumerator ladderSound()
    {
        is_climbSound = true;
        audioManager.PlaySfx(audioManager.ladder);
        yield return new WaitForSeconds(1.136f);
        is_climbSound = false;
    }
}
