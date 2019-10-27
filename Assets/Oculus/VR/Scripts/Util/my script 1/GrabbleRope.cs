using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleRope : OVRGrabbable
{
    bool inPlace;
    Transform parent;

    public List<Transform> hangingPosition;
    public List<GameObject> BottleRing;

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
            transform.parent = parent;
            transform.localPosition = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
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

            parent = other.GetComponent<HangerScript>().HangingPos;
            inPlace = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "HangerPositionPlace")
        {
            parent = null;
            inPlace = false;
        }
    }
}
