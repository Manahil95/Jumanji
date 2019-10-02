using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{
    public GameObject CloseButton;
    public GameObject moveGround;
    public GameObject Target;
    public GameObject AvatarPosition;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void MoveGround()
    {
        moveGround.transform.position = Vector3.MoveTowards(moveGround.transform.position, Target.transform.position, 10 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject == CloseButton)
        {
            InvokeRepeating("MoveGround", 0, Time.deltaTime);
        }

        if (collision.collider.tag=="MazeWall")
        {
            gameObject.transform.position = AvatarPosition.transform.position;
        }
    }


}
