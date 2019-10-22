using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject JumanjiTitlePanel;
    public Animation JumanjiTitleAnimation;
    private float open = 5.0f;
    private float delete = 10.0f;

    public GameObject JumanjiwordPanel;
    private float OpenumanjiwordPanel = 11.0f;
    private float DeleteumanjiwordPanel = 20.0f;

    void Start()
    {
       Invoke("ShowJumanjiTitlePanel", open);
       Invoke("HideJumanjiTitlePanel", delete);

       Invoke("ShowJumanjiwordPanel", OpenumanjiwordPanel);
       Invoke("HideJumanjiwordPanel", DeleteumanjiwordPanel);
    }
    void Update()
    {

    }
    void ShowJumanjiTitlePanel()
    {
        JumanjiTitlePanel.gameObject.SetActive(true);
        
    }
    void HideJumanjiTitlePanel()
    {
        JumanjiTitlePanel.gameObject.SetActive(false);
    }
    void ShowJumanjiwordPanel()
    {
        JumanjiwordPanel.gameObject.SetActive(true);
    }
    void HideJumanjiwordPanel()
    {
        JumanjiwordPanel.gameObject.SetActive(false);
    }
}
