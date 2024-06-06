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

    public int stage = 0;
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
        if (Input.GetKeyDown(KeyCode.S) && PlatformTUT.activeSelf == true)
        {
            PlatformTUT.SetActive(false);
        }
    }

    public void checkForStage(int stage)
    {
        if(stage == 1)
        {
            JumpTUT.SetActive(true);
        } else if(stage == 2)
        {
            PlatformTUT.SetActive(true);
        } 
    }
}
