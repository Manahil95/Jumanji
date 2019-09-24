using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleandPuzzle : MonoBehaviour
{
    [SerializeField] Transform hangerPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hanger")
        {
            other.transform.position = hangerPosition.position;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
