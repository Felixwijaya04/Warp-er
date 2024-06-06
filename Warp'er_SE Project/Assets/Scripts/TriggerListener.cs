using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerListener : MonoBehaviour
{
    public TutorialManager tm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("masuk");
        tm.stage++;
        tm.checkForStage(tm.stage);
    }
}
