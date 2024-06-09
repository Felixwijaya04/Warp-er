using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher_Counter : MonoBehaviour
{
    public Transform PointA; // Closed position
    public Transform PointB; // Open position
    public float speed;
    public CounterScript cs;

    private Vector3 nextPos;
    private bool isMoving = false;

    [SerializeField] private float bounce;
    // Update is called once per frame
    void Update()
    {
        if (cs.count == 3)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position == PointB.position)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
