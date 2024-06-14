using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed;
    public LeverScript ls;
    public changeSprite_Lever csl;
    private Vector3 nextPos;
    private bool isMoving = false;
    private int value = 1;

    [HideInInspector] public bool loc;
    public AudioManager audioManager;
    // Update is called once per frame

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Update()
    {
        csl.isODD = value;
        if (ls._isActivate == true || (Input.GetKeyDown(KeyCode.F) && ls._isPlayer == true))
        {
            check();
            if(value % 2 ==0)
            {
                audioManager.PlaySfx(audioManager.lever1);
            } else if(value % 2 !=0)
            {
                audioManager.PlaySfx(audioManager.lever2);
            }
            value++;
            
        }
        if(isMoving == true)
        {
            move();
        }
    }

    void move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        if(transform.position == nextPos)
        {
            isMoving = false;
        }
    }

    void check()
    {
        //determine destination
        if (transform.position == PointA.position)
        {
            nextPos = PointB.position;
            loc = true;
        }
        else if (transform.position == PointB.position)
        {
            nextPos = PointA.position;
            loc = false;
        }
        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            collision.gameObject.transform.parent = transform;
        }
        if (collision.gameObject.CompareTag("Wooden Crate"))
        {
            collision.gameObject.transform.parent = transform;
        }
        if (collision.gameObject.CompareTag("SwappableObject"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("Wooden Crate"))
        {
            collision.gameObject.transform.parent = null;
        }
        if (collision.gameObject.CompareTag("SwappableObject"))
        {
            collision.gameObject.transform.parent = null;
        }
    }
}
