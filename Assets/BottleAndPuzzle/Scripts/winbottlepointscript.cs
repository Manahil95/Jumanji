using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winbottlepointscript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "winbottlePlace")
        {
            other.GetComponent<winpointscipt>().Increment();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "winbottlePlace")
        {
            other.GetComponent<winpointscipt>().Decrement();
        }
    }
}
