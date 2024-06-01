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
    public GrabScript gs;

    private void Start()
    {
        pendant.transform.position = pendantHolder.position;
        pendant.transform.parent = pendantHolder;
        if (pendant.GetComponent<Rigidbody2D>())
        {
            pendant.GetComponent<Rigidbody2D>().simulated = false;
        }
        gs.isHoldingPendant = true;
    }
    void Update()
    {
        // if player is holding a pendant then player can throw
        if(gs.isHoldingPendant == true && Time.timeScale != 0f)
        {
            // to prevent multiple input when a pause button is click at the same time
            if (!UI_Manager.instance.IsPointerOverUIObject())
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = (mousePosition - transform.position).normalized;
                if (Input.GetMouseButtonDown(0))
                {
                    transform.parent = null;
                    if (GetComponent<Rigidbody2D>())
                    {
                        GetComponent<Rigidbody2D>().simulated = true;
                    }
                    pendant.velocity = new Vector2(direction.x * force, direction.y * force);
                    pendant.isKinematic = false;
                    /*pendant.GetComponent<PendantRotation>().canRotate = true;*/
                    gs.isHoldingPendant = false;
                }
            }
            
        }
    }
}
