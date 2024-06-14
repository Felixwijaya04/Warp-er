using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite_MPL : MonoBehaviour
{
    public Sprite sp1, sp2;
    public MovingPlatform mp;
    private void Update()
    {
        if (mp.loc == false)
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
        if (mp.loc == true)
        {
            GetComponent<SpriteRenderer>().sprite = sp2;
        }
    }
}
