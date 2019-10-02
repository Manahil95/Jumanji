using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMoveScript : MonoBehaviour
{
    public GameObject Avatar;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Move()
    {
        if (gameObject.tag == "Walk")
        {
            Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.forward * Time.deltaTime * 6);
        }
        if (gameObject.tag == "WalkBack")
        {
            Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.back * Time.deltaTime * 6);
        }
        if (gameObject.tag == "MoveRight")
        {
            Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.right * Time.deltaTime * 6);
        }
        if (gameObject.tag == "MoveLeft")
        {
            Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.left * Time.deltaTime * 6);
        }
    }
    private void OnMouseUp()
    {
        CancelInvoke();
    }
    private void OnMouseDown()
    {
        InvokeRepeating("Move", 0, Time.deltaTime);
    }

    
}

