using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public List<WaterTank> WaterConnector;
    Quaternion targetRotation;
    
    //Rigidbody rb;

    float time;
    bool canMove = true;
    float YRotation;

    public Vector3 handInitialPos;
    Vector3 handCurrentPos;

    public Transform hands;

    public float[] EndRotation;
    float currentEndRotation;
    int endRotationIndex;

    bool Direction = true;

    private void Start()
    {
        currentEndRotation = EndRotation[endRotationIndex];
    }

    void RotateObjects()
    {

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
        if (!canMove)
        {
            time = 0;
            canMove = true;
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

    public Vector3 crossVec;
    public float myYRotation;

    public void ActivateRotator()
    {
        if (canMove)
        {
            handCurrentPos = hands.position;
            crossVec = Vector3.Cross(new Vector3(handInitialPos.x, 0, handInitialPos.y), new Vector3(handCurrentPos.x, 0, handCurrentPos.y));
            //if (crossVec.y > 0)
            //{
                YRotation += Vector3.Angle(new Vector3(handCurrentPos.x, 0, handCurrentPos.y), new Vector3(handInitialPos.x, 0, handInitialPos.y));
                targetRotation = Quaternion.Euler(0, YRotation, 0.0f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);
                print(YRotation);

                myYRotation = transform.rotation.y;
                if (Direction)
                {
                    if (transform.rotation.y >= currentEndRotation)
                    {
                        canMove = false;
                        Invoke("StartRotationConnectors", 0);
                    }
                }
                else
                {
                    if (transform.rotation.y <= currentEndRotation)
                    {
                        canMove = false;
                        Invoke("StartRotationConnectors", 0);
                    }
                }
            //}
        }
    }

    void StartRotationConnectors()
    {
        foreach (var item in WaterConnector)
        {
            item.YRotation += 90;
            item.TargetRotation = Quaternion.Euler(0, item.YRotation, 0.0f);
        }

        Invoke("StopRotatingConnectors", 1);
        InvokeRepeating("RotateWaterConnectors", 0, Time.deltaTime);
    }

    void RotateWaterConnectors()
    {
        foreach (var item in WaterConnector)
        {
            item.transform.rotation = Quaternion.RotateTowards(item.transform.rotation, item.TargetRotation, 100 * Time.deltaTime);
        }
    }

    void StopRotatingConnectors()
    {
        CancelInvoke("RotateWaterConnectors");
        canMove = true;
        endRotationIndex++;
        if (endRotationIndex == 4)
            endRotationIndex = 0;

        if (endRotationIndex == 0 || endRotationIndex == 1)
            Direction = true;
        if (endRotationIndex == 2 || endRotationIndex == 3)
            Direction = false;

        currentEndRotation = EndRotation[endRotationIndex];
    }
}
