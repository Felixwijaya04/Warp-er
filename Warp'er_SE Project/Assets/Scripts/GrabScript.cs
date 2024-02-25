using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public Transform boxHolder;
    public static bool isHolding = false;
    [SerializeField] Transform box;
    [SerializeField] float range;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, box.position);
        print(distance);
        if (distance < range)
        {
            if(Input.GetMouseButtonDown(1) && isHolding == false)
            {
                box.transform.position = boxHolder.position;
                box.transform.parent = transform;
                isHolding = true;
                if (box.GetComponent<Rigidbody2D>())
                {
                    box.GetComponent<Rigidbody2D>().simulated = false;
                }

            } else if(Input.GetMouseButtonDown(1) && isHolding == true) { 
                isHolding=false;
                box.transform.parent = null;
                if (box.GetComponent<Rigidbody2D>())
                {
                    box.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }
    }
}
