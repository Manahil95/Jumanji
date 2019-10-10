using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleRope : OVRGrabbable
{
    public HangerScript hangerSript;
    bool inPlace;
    Transform hangerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }

    private void OnTriggerStay(Collider other)
    {
        if (myType == Type.Rope)
        {
            if (other.tag == "HangerPositionPlace")
            {
                Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, 0.1f);

                foreach (var item in overlappedColliders)
                {
                    if (item != GetComponent<Collider>())
                    {
                        if (item.tag == "Hanger")
                            return;
                    }
                }

                hangerSript.HangingPos = hangerPosition;
                hangerPosition = other.transform;
                inPlace = true;
            }
        }
    }
    private void OnTriggerExit (Collider other)
    {
        if (myType == Type.Rope)
        {
            if (other.tag == "HangerPositionPlace")
            {
                hangerPosition = null;
                inPlace = false;
            }
        }
    }
}
