using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PendantScript : MonoBehaviour
{
    public Transform pendantHolder;
    [SerializeField] Transform pendant;
    [SerializeField] float force;
    private Vector2 direction;

    private void Start()
    {
        pendant.transform.position = pendantHolder.position;
        pendant.transform.parent = pendantHolder;
        if (pendant.GetComponent<Rigidbody2D>())
        {
            pendant.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
    void Update()
    {
        if(GrabScript.isHolding == false)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
        }
    }
}
