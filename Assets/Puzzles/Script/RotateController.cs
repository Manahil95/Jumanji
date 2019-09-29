using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateController : MonoBehaviour
{
    public List<WaterTank> WaterConnector;
    Quaternion targetRotation;
    //Rigidbody rb;

    float time;
    bool move;
    float YRotation;

    Vector3 handInitialPos;
    Vector3 handCurrentPos;

    public Transform hands;

    void RotateObjects()
    {
        time += Time.deltaTime;
        handCurrentPos = hands.position;
        YRotation = Vector3.Angle(handInitialPos, handCurrentPos);
        myText.text = YRotation.ToString();
        targetRotation = Quaternion.Euler(0, YRotation, 0.0f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);

        //foreach (var item in WaterConnector)
        //{
        //    item.transform.rotation = Quaternion.RotateTowards(item.transform.rotation, item.TargetRotation, 100 * Time.deltaTime);
        //}

        //if (time >= 1)
        //{
        //    CancelInvoke();
        //    move = false;
        //}
    }

    private void OnMouseDown()
    {
        if (!move)
        {
            time = 0;
            move = true;
            YRotation += 90;
            targetRotation = Quaternion.Euler(0, YRotation, 0.0f);

            foreach (var item in WaterConnector)
            {
                item.YRotation += 90;
                item.TargetRotation = Quaternion.Euler(0, item.YRotation, 0.0f);
            }

            InvokeRepeating("RotateObjects", 0, Time.deltaTime);
        }
    }

    public Text myText;

    private void OnCollisionEnter(Collision collision)
    {
        if (!move)
        {
            if (collision.gameObject.tag == "hand")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
                {
                    handInitialPos = hands.position;
                    InvokeRepeating("RotateObjects", 0, Time.deltaTime);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        CancelInvoke();
    }

}
