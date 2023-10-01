using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Global Variable")]

public class GlobalVariable : ScriptableObject
{
    public bool goBackToMonkey;
    public bool justDoIt;
    public bool keepMoving;
    public bool toInfinityAndBeyond;
    public bool alwaysHigher;
    public bool stayDetermined;

    public void getSuccess(int id)
    {
        switch (id)
        {
            case 0:
                goBackToMonkey = true;
                break;
            case 1:
                justDoIt = true;
                break;
            case 2:
                keepMoving = true;
                break;
            case 3:
                toInfinityAndBeyond = true;
                break;
            case 4:
                alwaysHigher = true;
                break;
            case 5:
                stayDetermined = true;
                break;
        }
    }
}