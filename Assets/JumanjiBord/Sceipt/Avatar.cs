using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avatar : MonoBehaviour
{
    public Transform[] wayPoints;
    public int wayPointsIndex = 0;
    public float minDist;
    public float speed;
    public bool Go;

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, wayPoints[wayPointsIndex].transform.position);
        
        if(Go)
        {
            if(dist > minDist)
            {
                Move();
            }

        }
    }

    public void Move()
    {
        gameObject.transform.LookAt(wayPoints[wayPointsIndex].transform.position);
        gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
    }
}
