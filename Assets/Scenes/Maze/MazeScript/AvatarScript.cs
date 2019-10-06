using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{
    public GameObject CloseButton;
    public GameObject moveGround;
    public GameObject Target;
    public GameObject AvatarPosition;
    public GameObject xWall;
    public GameObject xWallTarget;

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

        int score=0 ;
        if (collision.collider.tag == "coin")
        {
            score += 1;
            Destroy(collision.gameObject);
            print(score);

            if (score == 5)
            {
                xWall.transform.position = Vector3.MoveTowards(xWall.transform.position, xWallTarget.transform.position, 0.5f * Time.deltaTime);
            }
        }
        
    }


}
