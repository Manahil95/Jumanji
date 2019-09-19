using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    
    private float Speed = 3f;

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
            if (gameObject.tag=="Walk")
            {
                transform.position += new Vector3(transform.position.x * Speed, 0, 0);
            }
            if (gameObject.tag == "MoveRight")
            {

            }
            if (gameObject.tag == "MoveLeft")
            {

            }
        }
    }

}
