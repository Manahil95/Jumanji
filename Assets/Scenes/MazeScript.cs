using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray,out hit))
        {
            if(hit.transform.name == "MoveRight")
            {

            }
            if (hit.transform.name == "MoveLeft")
            {

            }
            if (hit.transform.name == "Walk")
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
