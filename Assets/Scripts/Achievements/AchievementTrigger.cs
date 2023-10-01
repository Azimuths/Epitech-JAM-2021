using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementTrigger : MonoBehaviour
{
    public Achievements achievement;
    public bool isAchieved = false;

    public void TriggerAchievement ()
    {
        FindObjectOfType<AchievementManager>().StartAchievement(achievement);
    }
}
