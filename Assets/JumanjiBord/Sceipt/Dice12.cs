using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice12 : MonoBehaviour
{
    static Rigidbody rb;
    public Vector3 diceVelocity;
    public static bool thrown = false;
    public static bool InTheZone = false;
    bool Stop = true;

    public float speed = 2f;
    public Material M_material;
    Vector3 originalPos;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        originalPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        diceVelocity = rb.velocity;

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    DiceNumberTextScript.diceNumber1 = 0;
        //    float dirX = Random.Range(0, 500);
        //    float dirY = Random.Range(0, 500);
        //    float dirZ = Random.Range(0, 500);
        //    transform.position = new Vector3(0, 2, 0);
        //    transform.rotation = Quaternion.identity;
        //    rb.AddForce(transform.up * 100);
        //    rb.AddTorque(dirX, dirY, dirZ);
        //}
        if(Stop)
        {
            float lerp = Mathf.PingPong(Time.time, speed) / speed;
            GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.red, lerp);
        }
        else
        {
            GetComponent<Renderer>().material = M_material;
        }
       

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            transform.position = originalPos;

        if(tag == "Dice2" && collision.gameObject.tag == "CheckZone" && thrown && Game_Play.Instance.PuzzleFinished)
        {
            InTheZone = true;

            Invoke("StopDice", 1);
        }

        if (collision.gameObject.tag == "hand")
            Stop = false;

    }

    void StopDice()
    {
        rb.velocity = Vector3.zero;
    }
}
