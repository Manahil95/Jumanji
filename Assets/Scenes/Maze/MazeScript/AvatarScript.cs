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
    public int score = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void MoveGround()
    {
        moveGround.transform.position = Vector3.MoveTowards(moveGround.transform.position, Target.transform.position, 20 * Time.deltaTime);
    }

    private void MoveWall()
    {
        xWall.transform.position = Vector3.MoveTowards(xWall.transform.position, xWallTarget.transform.position, 0.5f * Time.deltaTime);
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

        
        if (collision.collider.tag == "coin")
        {
            Destroy(collision.gameObject);
            score += 1;
            Debug.Log(score);

            if (score == 5)
            {
                InvokeRepeating("MoveWall", 0, Time.deltaTime);
            }
        }

        
    }


}
