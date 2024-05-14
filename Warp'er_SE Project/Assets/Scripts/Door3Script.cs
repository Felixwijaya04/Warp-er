using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Script : MonoBehaviour
{
    public Transform PointA; // Closed position
    public Transform PointB; // Open position
    public float speed;
    public PlateScript ps;

    private Vector3 nextPos;
    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        if (ps._isActivate)
        {
            // Move towards open position
            nextPos = PointB.position;
        }
        else
        {
            // Move towards closed position
            nextPos = PointA.position;
        }

        // Start moving if not already at the desired position
        if (transform.position != nextPos)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        if (transform.position == nextPos)
        {
            isMoving = false;
        }
    }
}
