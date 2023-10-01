using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditText : MonoBehaviour
{
    public GameObject AfterEnding;

    public void EnableButton()
    {
        AfterEnding.SetActive(true);
    }
}
