using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievements
{
    public string title;
    [TextArea(1, 1)]
    public string[] description;
}