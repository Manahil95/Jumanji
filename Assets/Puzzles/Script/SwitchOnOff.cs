using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOnOff : MonoBehaviour
{

    public GameObject Water;

    float Speed = 5f;
    Vector3 temp;

    void ScaleWater()
    {
        temp = Water.transform.localScale;
        temp.x += Time.deltaTime;
        transform.localScale = temp;
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "ONOff")
        {
            InvokeRepeating("ScaleWater", 0, Time.deltaTime);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        CancelInvoke();
        Destroy(Water);
    }

}
