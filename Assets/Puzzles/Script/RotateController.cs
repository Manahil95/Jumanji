using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    public List<WaterTank> WaterConnector;

    float time;
    bool move;
    float YRotation;

    Quaternion targetRotation;

    private void Start()
    {
        //YRotation = transform.rotation.y;
        //angel = YRotation + 90;
    }

    void RotateObjects()
    {
        time += Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 100 * Time.deltaTime);

        foreach (var item in WaterConnector)
        {
            item.transform.rotation = Quaternion.RotateTowards(item.transform.rotation, item.TargetRotation, 100 * Time.deltaTime);
        }

        if (time >= 1)
        {
            CancelInvoke();
            move = false;
        }
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

}
