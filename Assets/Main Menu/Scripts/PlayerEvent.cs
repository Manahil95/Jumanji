using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvent : MonoBehaviour
{
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_Headnchor;

    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;

    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;


    private void Awake()
    {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDMounted += PlayerLost;
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDMounted -= PlayerLost;
    }

    private void Update()
    {
        if (!m_InputActive)
            return;

        CheckForController();
        CheckInputSource();
        Input();

    }
    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;

        if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) && !OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.Touchpad;

        m_Controller = UpdateSource(controllerCheck, m_Controller);
    }
    private void CheckInputSource()
    {
        m_InputSource = UpdateSource(OVRInput.GetActiveController(),m_InputSource);
    }
    private void Input()
    {
        //(OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if(OnTouchpadDown != null)
            {
                OnTouchpadDown();
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            if (OnTouchpadUp != null)
            {
                OnTouchpadUp();
            }
        }
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check,OVRInput.Controller previous)
    { 
        if(check == previous)
          return previous;

        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        if (controllerObject == null)
            controllerObject = m_Headnchor;

        if (OnControllerSource != null)
            OnControllerSource(check, controllerObject);
        return check;
    }
     
    private void PlayerFound()
    {
        m_InputActive = true;
    }

    private void PlayerLost()
    {
        m_InputActive = false;
    }

    private  Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {

            { OVRInput.Controller.LTrackedRemote,m_LeftAnchor},
            { OVRInput.Controller.RTrackedRemote,m_RightAnchor},
            {OVRInput.Controller.Touchpad,m_Headnchor }
        };
        return newSets;
    }

}
