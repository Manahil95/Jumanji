using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMoveScript : MonoBehaviour
{
    
    private float Speed = 0.3f;
    public GameObject Enemy;
    
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (gameObject.tag == "Walk")
            {
                Enemy.transform.position += Enemy.transform.TransformDirection(Vector3.forward);
            }
            if (gameObject.tag == "WalkBack")
            {
                Enemy.transform.position += Enemy.transform.TransformDirection(Vector3.back);
            }
            if (gameObject.tag == "MoveRight")
            {
                Enemy.transform.position += Enemy.transform.TransformDirection(Vector3.right);
            }
            if (gameObject.tag == "MoveLeft")
            {
                Enemy.transform.position += Enemy.transform.TransformDirection(Vector3.left);
            }
        }
    }
}

