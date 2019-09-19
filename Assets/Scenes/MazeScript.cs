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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (hit.collider.tag=="Walk")
            {
                Debug.Log(gameObject.name);
                transform.position += new Vector3(transform.position.x * Speed, 0, 0);
            }
            if (hit.collider.tag == "MoveRight")
            {

            }
            if (hit.collider.tag == "MoveLeft")
            {

            }
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag=="Walk")
            {
                transform.position = transform.forward * Speed;
            }
        }
    }

}
