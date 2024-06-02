using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Every Panel")]
    public GameObject MovementTUT;
    public GameObject JumpTUT;
    public GameObject PlatformTUT;
    public GameObject ThrowTUT;
    public GameObject TeleportTUT;

    private void Start()
    {
        MovementTUT.SetActive(true);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            MovementTUT.SetActive(false);
        }
    }
}
