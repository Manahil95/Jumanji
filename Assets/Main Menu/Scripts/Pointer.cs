using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float m_Distance = 10f;
    public LineRenderer m_LineRenderer = null;
    public LayerMask m_EverythingMask = 0;
    public LayerMask m_InteractableMask = 0;

    private void Awake()
    {
        PlayerEvent.OnControllerSource += UpdateOrigin;
        PlayerEvent.OnTouchpadDown += ProcessTouchpadDown;
;
    }

    private void OnDestroy()
    {
        PlayerEvent.OnControllerSource -= UpdateOrigin;
        PlayerEvent.OnTouchpadDown -= ProcessTouchpadDown;
    }

    private void UpdateOrigin(OVRInput.Controller controller ,GameObject controllerObject)
    {

    }

    private void ProcessTouchpadDown() 
    {

    
    }
}
