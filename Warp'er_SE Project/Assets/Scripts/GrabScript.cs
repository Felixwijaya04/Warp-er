using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabScript : MonoBehaviour
{
    public Transform boxHolder;
    public static bool isHolding = false;
    private bool _thisObjPaired = false;
    [SerializeField] Transform box;
    [SerializeField] float range;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, box.position);
        Debug.Log(PlayerScript.SwapQuota);
        if (distance < range)
        {
            // validasi dulu apakah swap quota tersedia atau tidak
            if(Input.GetKeyDown(KeyCode.Q) && PlayerScript.SwapQuota == true)
            {
                // jika tersedia maka swap quota skrg habis dan object ini bisa untuk swap diri
                PlayerScript.SwapQuota = false;
                _thisObjPaired = true;
            }
            else if(Input.GetKeyDown(KeyCode.Q) && PlayerScript.SwapQuota == false)
            {
                // swap quota tersedia lagi
                PlayerScript.SwapQuota = true;
                _thisObjPaired = false;
            }


            if (Input.GetMouseButtonDown(1) && isHolding == false && _thisObjPaired == true)
            {
                box.transform.position = boxHolder.position;
                box.transform.parent = transform;
                isHolding = true;
                if (box.GetComponent<Rigidbody2D>())
                {
                    box.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
            else if (Input.GetMouseButtonDown(1) && isHolding == true && _thisObjPaired == true)
            {
                isHolding = false;
                box.transform.parent = null;
                if (box.GetComponent<Rigidbody2D>())
                {
                    box.GetComponent<Rigidbody2D>().simulated = true;
                }
            }
        }
    }
}
