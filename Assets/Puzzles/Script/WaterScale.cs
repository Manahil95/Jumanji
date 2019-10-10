using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScale : MonoBehaviour
{
    //float Speed = 5f;
    Vector3 temp;

    public void ScaleWater()
    { 
       temp = transform.localScale;
       if (temp.x <= 2.3f)
       {
         temp.x += Time.deltaTime;
         temp.y += Time.deltaTime;
         temp.z += Time.deltaTime;
         transform.localScale = temp;
       }

    }
 
}
