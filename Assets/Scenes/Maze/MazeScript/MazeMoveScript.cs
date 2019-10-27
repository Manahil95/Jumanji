using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMoveScript : MonoBehaviour
{   
    public Transform pointA, pointB;
    public float speed;
    private bool direction;
    float previousTime;
    float time;

    void Update()
    {        
        if (pointA!= null)
        {
             time = Mathf.PingPong(Time.time * speed, 1);
            transform.position = Vector3.Lerp(pointA.position, pointB.position, time);
        }
        if (previousTime < time)
            direction = true;
        else if (previousTime > time)
            direction = false;
        Rotate();
        previousTime = time;
    }   

    private void Rotate()
    {
        if(direction)
        transform.Rotate(0, 0, -5);
        else
            transform.Rotate(0, 0, 5);
    }
}

