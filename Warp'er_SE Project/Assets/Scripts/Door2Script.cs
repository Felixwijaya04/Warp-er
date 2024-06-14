using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Script : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed;
    public LeverScript ls;

    private Vector3 nextPos;
    private bool isMoving = false;
    [HideInInspector] public bool loc;
    public AudioManager audioManager;
    public changeSprite_Lever csl;
    private int value = 1;
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
            if(value % 2 == 0)
            {
                audioManager.PlaySfx(audioManager.lever1);
            } else if(value % 2 !=0)
            {
                audioManager.PlaySfx(audioManager.lever2);
            }
            value++;
        }
        if (isMoving == true)
        {
            move();
        }
    }

    void move()
    {

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        if (transform.position == nextPos)
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
}
