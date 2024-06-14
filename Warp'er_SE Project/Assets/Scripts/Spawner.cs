using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trashBag;
    public LeverScript ls;
    public changeSprite_Lever csl;
    [SerializeField] private int limit;
    private int value = 1;
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        csl.isODD = value;
        if(limit > 0)
        {
            if(ls._isPlayer == true && Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(trashBag,transform.position,Quaternion.identity);
                limit--;
                if(value % 2 == 0)
                {
                    audioManager.PlaySfx(audioManager.lever1);
                } else if(value % 2 != 0)
                {
                    audioManager.PlaySfx(audioManager.lever2);
                }
                value++;
            }
        }
        
    }
}
