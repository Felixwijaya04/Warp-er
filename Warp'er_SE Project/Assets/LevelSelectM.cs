using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectM : MonoBehaviour
{
    [Header("Script Ref")]
    public UI_Manager manager;
    public int stage;

    [Header("Object Ref")]
    public GameObject Tutor;
    public GameObject TutorDone;
    public GameObject Level1Done;
    public GameObject Level2Done;
    public GameObject Level3Done;
    public GameObject Level4Done;
    public GameObject Level5Done;

    private void Update()
    {
        stage = UI_Manager.LevelStage;
        Debug.Log(stage);
        checkLevelStage();
    }
    public void checkLevelStage()
    {
        if(stage == 1) //tutor done
        {
            Tutor.SetActive(false);
            TutorDone.SetActive(true);
        } else if (stage == 2) //level 1 done
        {
            Tutor.SetActive(false);
            TutorDone.SetActive(false);
            Level1Done.SetActive(true);
        } else if (stage == 3) //level 2 done
        {
            Tutor.SetActive(false);
            TutorDone.SetActive(false);
            Level1Done.SetActive(false);
            Level2Done.SetActive(true);
        } else if (stage == 4) //level 3 done
        {
            Tutor.SetActive(false);
            TutorDone.SetActive(false);
            Level1Done.SetActive(false);
            Level2Done.SetActive(false);
            Level3Done.SetActive(true);
        } else if (stage == 5) //level 4 done
        {
            Tutor.SetActive(false);
            TutorDone.SetActive(false);
            Level1Done.SetActive(false);
            Level2Done.SetActive(false);
            Level3Done.SetActive(false);
            Level4Done.SetActive(true);
        } else if (stage == 6) //level 5 done
        {
            Tutor.SetActive(false);
            TutorDone.SetActive(false);
            Level1Done.SetActive(false);
            Level2Done.SetActive(false);
            Level3Done.SetActive(false);
            Level4Done.SetActive(false);
            Level5Done.SetActive(true);
        }
    }
}
