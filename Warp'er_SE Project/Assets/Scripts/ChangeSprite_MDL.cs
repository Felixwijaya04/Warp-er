using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite sp1, sp2;
    public Door2Script door;

    private void Update()
    {
        if(door.loc == false)
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
        if(door.loc == true)
        {
            GetComponent<SpriteRenderer>().sprite = sp2;
        }
    }
}
