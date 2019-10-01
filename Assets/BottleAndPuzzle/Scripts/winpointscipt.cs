using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winpointscipt : MonoBehaviour
{
    public GameObject box;
    public Material Material1;
    int i = 0;
    public void Increment()
    {
        i++;
        if (i == 3)
        {
            box.GetComponent<MeshRenderer>().material = Material1;
        }
    }

    public void Decrement()
    {
        i--;
    }
}
