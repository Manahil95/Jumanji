using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{

    public GameObject Water;

    float Speed = 5f;
    Vector3 temp;
    private void Start()
    {
        
    }
    void ScaleWater()
    {
        temp = Water.transform.localScale;
        temp.x += Time.deltaTime;
        transform.localScale = temp;
    }
    private void OnTriggerEnter(Collider other)
    {
        print("Hi");
    }
    private void OnTriggrerStay(Collision other)
    {
        if(other.gameObject.tag == "ONOff")// && other.gameObject.tag == "Wall")
        {
            print("Alesta");
            InvokeRepeating("ScaleWater", 0, Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CancelInvoke();
        Destroy(Water);
    }
   

}
