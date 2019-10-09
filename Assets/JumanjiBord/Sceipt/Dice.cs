using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    bool hasLanded;
    bool thrown;
    Vector3 initPostion;
    public int DiceValue;
    public DiceSide[] diceSides;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPostion = transform.position;
       // rb.useGravity = false;
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space)  /* || (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))*/)
       {
          RollDice();
       }

        if (rb.IsSleeping() && !hasLanded && thrown )
        {
            hasLanded = true;
           // rb.useGravity = false;
            SideValueCheck();
        }
        else if(rb.IsSleeping() && hasLanded && DiceValue == 0)
        {
            RollAgain();
        }
    }

    void RollDice()
    {
        if(!thrown && !hasLanded)
        {
            thrown = true;
           // rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }

        else if(thrown && hasLanded)
        {
            Rest();
        }
    }

    void Rest()
    {
        transform.position = initPostion;
        thrown = false;
        hasLanded = false;
       // rb.useGravity = false;
    }

    void RollAgain()
    {
        Rest();
        thrown = true;
        //rb.useGravity = true;
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    void SideValueCheck()
    {
        DiceValue = 0;
        foreach(DiceSide side in diceSides)
        {
            if(side.OnGround())
            {
                DiceValue = side.sideValue;
                Debug.Log(DiceValue + "has been rolled! ");
            }
        }
    }
}
