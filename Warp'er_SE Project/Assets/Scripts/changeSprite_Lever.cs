using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite_Lever : MonoBehaviour
{
    public Sprite sp1, sp2;
    [HideInInspector]public int isODD;

    private void Update()
    {
        if(isODD % 2 == 0) //jika genap
        {
            GetComponent<SpriteRenderer>().sprite = sp2;
        }
        if(isODD % 2 != 0)
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
    }
}
