using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillTank : MonoBehaviour
{
    public Transform Water;
    public Transform Target;

    public void RaiseWater()
    {
        Water.position = Vector3.MoveTowards(Water.position, Target.position, 0.005f);
    }
 
}
