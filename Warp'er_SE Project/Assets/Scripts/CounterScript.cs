using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterScript : MonoBehaviour
{
    [SerializeField] public int count;
    public Sprite sp1, sp2, sp3;
    private void Update()
    {
        if (count == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
        if(count == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sp1;
        }
        if(count == 2)
        {
            GetComponent<SpriteRenderer>().sprite = sp2;
        }
        if (count == 3)
        {
            GetComponent<SpriteRenderer>().sprite = sp3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            Destroy(collision.gameObject);
            count++;
        }
    }
}
