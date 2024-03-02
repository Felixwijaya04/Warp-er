using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PendantScript : MonoBehaviour
{
    public Transform pendantHolder;
    [SerializeField] private Rigidbody2D pendant;
    [SerializeField] float force;
    [SerializeField] float range;
    private Vector2 direction;
    

    private void Start()
    {
        pendant.transform.position = pendantHolder.position;
        pendant.transform.parent = pendantHolder;
        if (pendant.GetComponent<Rigidbody2D>())
        {
            pendant.GetComponent<Rigidbody2D>().simulated = false;
        }
        GrabScript.isHoldingPendant = true;
    }
    void Update()
    {
        
        if(GrabScript.isHoldingPendant == true)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            if(Input.GetMouseButtonDown(0))
            {
                transform.parent = null;
                if (GetComponent<Rigidbody2D>())
                {
                    GetComponent<Rigidbody2D>().simulated = true;
                }
                pendant.velocity = new Vector2(direction.x * force, direction.y * force);
                pendant.isKinematic = false;
                pendant.GetComponent<PendantRotation>().canRotate = true;
                GrabScript.isHoldingPendant = false;
            }
        }
    }
}
