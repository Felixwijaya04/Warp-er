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
    private void Update()
    {
        csl.isODD = value;
        if(limit > 0)
        {
            if(ls._isPlayer == true && Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(trashBag,transform.position,Quaternion.identity);
                limit--;
                value++;
            }
        }
        
    }
}
