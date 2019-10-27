using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleBottle : OVRGrabbable
{
    bool inPlace;
    public int ID;
    Transform hangerPosition;

    GameObject rope;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        if (inPlace)
        {
            rb.isKinematic = true;
            rope.GetComponent<GrabbleRope>().BottleRing[ID].GetComponent<MeshRenderer>().enabled = true;
            print(rope.GetComponent<GrabbleRope>().BottleRing[ID]);
            hangerPosition = rope.GetComponent<GrabbleRope>().hangingPosition[ID];
            transform.parent = hangerPosition;
            transform.localPosition = Vector3.zero;
        }
        else
        {
            rope.GetComponent<GrabbleRope>().BottleRing[ID].GetComponent<MeshRenderer>().enabled = false;
            hangerPosition = null;
            transform.parent = null;

            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rope")
        {
            rope = other.transform.parent.gameObject;

            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, 0.3f);

            foreach (var item in overlappedColliders)
            {
                if (item != GetComponent<Collider>())
                {
                    if (item.tag == "Bottle")
                        return;
                }
            }

            inPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rope")
        {
            inPlace = false;
        }
    }
}
