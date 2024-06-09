using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pusher_Btn : MonoBehaviour
{
    public Transform PointA;
    public Transform PointB;
    public float speed;
    public ButtonScript bs;
    public float bounce;

    private Vector3 nextPos;
    private bool isMoving = false;
    
    // Update is called once per frame
    void Update()
    {
        if (bs._isActivate == true || (Input.GetKeyDown(KeyCode.F) && bs._isPlayer == true))
        {
            check();
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
        }
        else if (transform.position == PointB.position)
        {
            nextPos = PointA.position;
            
        }
        isMoving = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && transform.position == PointB.position)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            
        }
    }
}
