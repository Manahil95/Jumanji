using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScale : MonoBehaviour
{
    float Speed = 5f;
    Vector3 temp;
  
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScaleWater", 0, Time.deltaTime);
    }

    void ScaleWater()
    { 
       temp = transform.localScale;
       if (temp.x <= 3)
       {
         temp.x += Time.deltaTime;
         transform.localScale = temp;
       }

    }

    

 
    
}
