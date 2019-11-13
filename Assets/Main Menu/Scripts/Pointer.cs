using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float m_Distance = 10f;
    public LineRenderer m_LineRenderer = null;
    public LayerMask m_EverythingMask = 0;
    public LayerMask m_InteractableMask = 0;


    private Transform m_CurrentOrigin = null ;


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

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 hitPoint = UpdateLine();
    }

    private Vector3 UpdateLine()
    {
        RaycastHit hit = CreateRaycast(m_EverythingMask);

        Vector3 endPosition = m_CurrentOrigin.position + (m_CurrentOrigin.forward * m_Distance);

        if(hit.collider != null)
        {
            endPosition = hit.point;

        }

        m_LineRenderer.SetPosition(0, m_CurrentOrigin.position);
        m_LineRenderer.SetPosition(1, endPosition);

        return endPosition;
    }

    private void UpdateOrigin(OVRInput.Controller controller ,GameObject controllerObject)
    {
        m_CurrentOrigin = controllerObject.transform;

        if(controller == OVRInput.Controller.Touchpad)
        {
            m_LineRenderer.enabled = false;

        }else
        {
            m_LineRenderer.enabled = true;
        }
    }

    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;
        Ray ray = new Ray(m_CurrentOrigin.position, m_CurrentOrigin.forward);
        Physics.Raycast(ray, out hit, m_Distance, layer);

        return hit;
    }
    private void SetLineColor()
    {
        if (!m_LineRenderer)
            return;

        Color endColor = Color.white;
        endColor.a = 0.0f;
        m_LineRenderer.endColor = endColor;
    }
    private void ProcessTouchpadDown() 
    {

    
    }
}
