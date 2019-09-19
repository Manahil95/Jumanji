using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hold : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mOffset;
    }

    ////private Vector3 screenPoint;
    ////private Vector3 offset;

    ////void OnMouseDown()
    ////{
    ////    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    ////    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    ////}

    ////void OnMouseDrag()
    ////{
    ////    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

    ////    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) - offset;

    ////    transform.position = curPosition;

    ////}

    //void OnMouseDrag()
    //{
    //    float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    //    transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

    //}


}
