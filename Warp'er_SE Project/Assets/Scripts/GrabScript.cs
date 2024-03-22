using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public Transform boxHolder;
    public Transform pendantHolder;
    public static bool isHolding = false;
    public static bool isHoldingPendant = true;
    public static bool justGrabBox = false;
    [SerializeField] Transform box;
    [SerializeField] Transform pendant;
    [SerializeField] float range;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, box.position);
        float PendantDist = Vector2.Distance(transform.position, pendant.position);
        
        if (distance < range)
        {
            if (Input.GetMouseButtonDown(1) && isHolding == false)
            {
                justGrabBox = true;
                /*box.transform.position = boxHolder.position;
                box.transform.parent = transform;
                isHolding = true;
                if (box.GetComponent<Rigidbody2D>())
                {
                    box.GetComponent<Rigidbody2D>().simulated = false;
                }*/
                Invoke("delayGrab", 0.2f);
            }
            // pendantDist > range agar input box dan pendant ga ke run bersamaan
            else if (Input.GetMouseButtonDown(1) && isHolding == true && PendantDist > range)
            {
                isHolding = false;
                box.transform.parent = null;
                if (box.GetComponent<Rigidbody2D>())
                {
                    box.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }

        if (PendantDist < range)
        {
            if (Input.GetMouseButtonDown(1) && isHoldingPendant == false)
            {
                pendant.transform.position = pendantHolder.position;
                pendant.transform.parent = pendantHolder;
                pendant.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
                if (pendant.GetComponent<Rigidbody2D>())
                {
                    pendant.GetComponent<Rigidbody2D>().simulated = false;
                }
                isHoldingPendant = true;
            }
            
        }
    }

    void delayGrab()
    {
        box.transform.position = boxHolder.position;
        box.transform.parent = transform;
        isHolding = true;
        if (box.GetComponent<Rigidbody2D>())
        {
            box.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}