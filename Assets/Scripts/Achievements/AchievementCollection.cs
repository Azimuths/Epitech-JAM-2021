using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementCollection : MonoBehaviour
{
    public List<AchievementTrigger> atriggerList;

    public bool isAchieved(int index)
    {
        return atriggerList[index].isAchieved;
    }

    public void activateAchievement(int index)
    {
        atriggerList[index].TriggerAchievement();
        atriggerList[index].isAchieved = true;
    }
}
