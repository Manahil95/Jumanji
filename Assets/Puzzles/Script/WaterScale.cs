using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScale : MonoBehaviour
{
    //float Speed = 5f;
    Vector3 temp;


    private void Start()
    {
      //InvokeRepeating("ScaleWater", 0, Time.deltaTime);
    }
    public void ScaleWater()
    { 
       temp = transform.localScale;
       if (temp.x <= 0.8f)
       {
         temp.x += Time.deltaTime;
         transform.localScale = temp;
       }

       if(temp.y <= 0.45f)
        {
          temp.y += Time.deltaTime;
          transform.localScale = temp;
        }

       if(temp.z <= 0.1f)
        {
          temp.z += Time.deltaTime;
          transform.localScale = temp;
        }

    }
 
}
