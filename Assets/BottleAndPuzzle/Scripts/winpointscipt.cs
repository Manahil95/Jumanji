using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winpointscipt : MonoBehaviour
{
    public GameObject UI;
    int i = 0;

    public void Increment()
    {
        i++;
        if (i >= 4)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }
    }

    public void Decrement()
    {
        i--;
    }
}
