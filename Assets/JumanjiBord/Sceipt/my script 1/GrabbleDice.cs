using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbleDice : OVRGrabbable
{
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        if (gameObject.tag == "Dice2")
            GetComponent<Dice12>().WhiteMat();
    }
}
