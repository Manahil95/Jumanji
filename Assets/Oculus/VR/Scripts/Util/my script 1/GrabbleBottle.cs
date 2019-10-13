using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleBottle : OVRGrabbable
{
    bool inPlace;
    public int ID;
    Transform hangerPosition;

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        if (inPlace)
        {
            rb.isKinematic = true;
            transform.position = hangerPosition.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Rope")
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, 0.1f);

            foreach (var item in overlappedColliders)
            {
                if (item != GetComponent<Collider>())
                {
                    if (item.tag == "Bottle")
                        return;
                }
            }

            other.GetComponent<GrabbleRope>().BottleRing[ID].GetComponent<MeshRenderer>().enabled = true;
            hangerPosition = other.GetComponent<GrabbleRope>().hangingPosition;
            transform.parent = other.GetComponent<GrabbleRope>().BottleParent[ID];
            inPlace = true;
        }

    }

}
