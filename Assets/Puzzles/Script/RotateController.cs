using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public List<GameObject> WaterConnector;
   
    public float time;
    bool direction;
    bool move;

    void RotateObjects()
    {
        time += Time.deltaTime;


        if (direction)
        {

            transform.eulerAngles = Vector3.Lerp(Vector3.zero, Vector3.up * 90, time);
            foreach (var item in WaterConnector)
            {
                item.transform.eulerAngles = Vector3.Lerp(Vector3.zero, Vector3.up * 90, time);
            }
        }
        else
        {

            transform.eulerAngles = Vector3.Lerp(Vector3.up * 90, Vector3.zero, time);
            foreach (var item in WaterConnector)
            {
                item.transform.eulerAngles = Vector3.Lerp(Vector3.up * 90, Vector3.zero, time);
            }
            
        }

        
    }

    private void OnMouseDown()
    {
        time = 0;
        direction = !direction;
        InvokeRepeating("RotateObjects", 0, Time.deltaTime);

        //if (!move)
        //{
        //    CancelInvoke("RotateObjects");
        //}
    }

   


}
