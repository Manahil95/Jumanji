using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceGrabber : OVRGrabber
{
    protected override void GrabEnd()
    {
        if (m_grabbedObj != null)
            Dice12.thrown = true;

        base.GrabEnd();
    }
}
