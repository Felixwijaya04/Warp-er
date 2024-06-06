using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Every Panel",order = 0)]
    public GameObject MovementTUT;
    public GameObject JumpTUT;
    public GameObject PlatformTUT;
    public GameObject ThrowTUT;
    public GameObject TeleportTUT;

    [Header("Every Colliders", order = 1)]
    public GameObject JumpCollider;
    public GameObject PlatformCollider;
    public GameObject ThrowCollider;

    private void Start()
    {
        MovementTUT.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Movement done");
            MovementTUT.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.W) && JumpTUT.activeSelf == true )
        {
            JumpTUT.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject == JumpCollider)
            {
                Debug.Log("yesJump");
                JumpTUT.SetActive(true);
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject == JumpCollider)
            {
                Debug.Log("yesJump");
                JumpTUT.SetActive(false);
            }

        }
    }
}
