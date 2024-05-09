using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed;
    public GameObject MP;

    private Vector3 nextPos;
    private bool isMoving = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && LeverScript._isPlayer == true)
        {
            check();
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
        if (MP.transform.position == PointA.position)
        {
            nextPos = PointB.position;
        }
        else if (MP.transform.position == PointB.position)
        {
            nextPos = PointA.position;
        }
        isMoving = true;
    }
}
