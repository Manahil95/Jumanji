using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] chiledObjects;
    public List<Transform> childeNodeList = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        FillNodes();

        for (int i = 0; i < childeNodeList.Count; i++)
        {
            Vector3 currenPos = childeNodeList[i].position;
            if( i > 0 )
            {
                Vector3 prevPos = childeNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currenPos);
            }
        }
    }

    void FillNodes()
    {
        childeNodeList.Clear();
        chiledObjects = GetComponentsInChildren<Transform>();
        foreach(Transform child in chiledObjects)
        {
            if(child != this.transform)
            {
                childeNodeList.Add(child);
            }
        }
    }
}
