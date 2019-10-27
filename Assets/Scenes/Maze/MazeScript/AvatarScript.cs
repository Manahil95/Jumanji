using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarScript : MonoBehaviour
{
    public GameObject Bridge;
    public GameObject AvatarPosition;
    public GameObject xWall;
    public GameObject xWallTarget;
    public AudioSource bridgeSound;

    int score = 0;

    void Start()
    {
        bridgeSound = GetComponent<AudioSource>();
    }

    void Update()
    {        
    }
    //private void MoveGround()
    //{
    //    moveGround.transform.position = Vector3.MoveTowards(moveGround.transform.position, Target.transform.position, 20 * Time.deltaTime);
    //}
    private void openDoor()
    {
        xWall.transform.position = Vector3.MoveTowards(xWall.transform.position, xWallTarget.transform.position, 0.2f * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.collider.tag == "Enemy")
        {
            gameObject.transform.position = AvatarPosition.transform.position;
        }

        if (collision.collider.tag == "coin")
        {
            Destroy(collision.gameObject);
            score += 1;
            if (score >= 1)
            {
                InvokeRepeating("openDoor", 0, Time.deltaTime);
            }
        }       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CloseButton")
        {
            Bridge.GetComponent<Animator>().SetBool("MoveBridge", true);
            bridgeSound.Play();
            //InvokeRepeating("MoveGround", 0, Time.deltaTime);
        }
    }
}
