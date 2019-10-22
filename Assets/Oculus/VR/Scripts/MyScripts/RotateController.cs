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
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);

        foreach (var item in WaterConnector)
        {
            item.transform.rotation = Quaternion.RotateTowards(item.transform.rotation, item.TargetRotation, 100 * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        YRotation += 90;
        targetRotation = Quaternion.Euler(-90, YRotation, 0.0f);

        foreach (var item in WaterConnector)
        {
            item.YRotation += 90;
            item.TargetRotation = Quaternion.Euler(0, item.YRotation, 0);

        }

        InvokeRepeating("RotateObjects", 0, Time.deltaTime);
    }

    public void ActivateRotator()
    {
        if (canMove)
        {
            YRotation += Vector3.Angle(new Vector3(hands.position.x, 0, hands.position.z), new Vector3(handInitialPos.x, 0, handInitialPos.z));
            targetRotation = Quaternion.Euler(-90, YRotation, 0.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);

            if (Direction)
            {
                if (Mathf.Abs(transform.rotation.y) >= currentEndRotation)
                {
                    canMove = false;
                    Invoke("StartRotationConnectors", 0);
                }
            }
            else
            {
                if (Mathf.Abs(transform.rotation.y) <= currentEndRotation)
                {
                    canMove = false;
                    Invoke("StartRotationConnectors", 0);
                }
            }
        }
    }

    void StartRotationConnectors()
    {
        foreach (var item in WaterConnector)
        {
            item.Moving = true;
            item.YRotation += 90;
            item.TargetRotation = Quaternion.Euler(0, item.YRotation, 0);
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
        foreach (var item in WaterConnector)
        {
            item.Moving = false;
        }
        canMove = true;
        endRotationIndex++;
        if (endRotationIndex == 4)
            endRotationIndex = 0;

        if (endRotationIndex == 0 || endRotationIndex == 1)
            Direction = true;
        if (endRotationIndex == 2 || endRotationIndex == 3)
            Direction = false;

        currentEndRotation = EndRotation[endRotationIndex];
        print(currentEndRotation);
        print(transform.rotation);
    }
}
