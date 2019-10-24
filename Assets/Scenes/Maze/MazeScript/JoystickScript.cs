using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickScript : OVRGrabber
{
    Vector3 initailPos;
    float xAngle, zAngle;
    Quaternion targetRotation;

    Quaternion initialRotation;

    public GameObject Avatar;

    protected override void GrabBegin()
    {
        initailPos = transform.position;
        xAngle = zAngle = 0;

        base.GrabBegin();

        initialRotation = m_grabbedObj.transform.localRotation;
    }

    protected override void MoveGrabbedObject(Vector3 pos, Quaternion rot, bool forceTeleport = false)
    {
        if (m_grabbedObj == null)
        {
            return;
        }

        float z = Vector3.ClampMagnitude(transform.position - initailPos, 1).z * 10;
        float x = Vector3.ClampMagnitude(transform.position - initailPos, 1).x * 7;

        if (Mathf.Abs(z) > Mathf.Abs(x))
        {
            if (z > 0.1f)
            {
                zAngle = Vector3.Angle(new Vector3(transform.position.x, transform.position.y, transform.position.z * 10), initailPos);
                targetRotation = Quaternion.Euler(zAngle, 0, 0);
                m_grabbedObj.grabbedRigidbody.transform.rotation = Quaternion.RotateTowards(m_grabbedObj.grabbedRigidbody.transform.rotation, targetRotation, 100 * Time.deltaTime);

                Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.down * Time.deltaTime * 0.7f);

            }
            else if (z < -0.1f)
            {
                zAngle = Vector3.Angle(new Vector3(transform.position.x, transform.position.y, transform.position.z * 10), initailPos);
                targetRotation = Quaternion.Euler(-zAngle, 0, 0);
                m_grabbedObj.grabbedRigidbody.transform.rotation = Quaternion.RotateTowards(m_grabbedObj.grabbedRigidbody.transform.rotation, targetRotation, 100 * Time.deltaTime);

                Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.up * Time.deltaTime * 0.7f);
            }
        }
        else if (Mathf.Abs(x) > Mathf.Abs(z))
        {
            if (x > 0.1f)
            {
                xAngle = Vector3.Angle(new Vector3(transform.position.x * 10, transform.position.y, transform.position.z), initailPos);
                targetRotation = Quaternion.Euler(0, 0, -xAngle);
                m_grabbedObj.grabbedRigidbody.transform.rotation = Quaternion.RotateTowards(m_grabbedObj.grabbedRigidbody.transform.rotation, targetRotation, 100 * Time.deltaTime);

                Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.right * Time.deltaTime * 0.7f);

            }
            else if (x < -0.1f)
            {
                xAngle = Vector3.Angle(new Vector3(transform.position.x * 10, transform.position.y, transform.position.z), initailPos);
                targetRotation = Quaternion.Euler(0, 0, xAngle);
                m_grabbedObj.grabbedRigidbody.transform.rotation = Quaternion.RotateTowards(m_grabbedObj.grabbedRigidbody.transform.rotation, targetRotation, 100 * Time.deltaTime);

                Avatar.transform.position += Avatar.transform.TransformDirection(Vector3.left * Time.deltaTime * 0.7f);
            }
        }
    }

    protected override void GrabEnd()
    {
        if (m_grabbedObj != null)
            m_grabbedObj.transform.localRotation = initialRotation;

        base.GrabEnd();
    }
}
