using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public AudioSource Drums;
    public GameObject JumanjiTitlePanel;
    private float open = 10.0f;
    private float delete = 15.0f;

    public GameObject JumanjiwordPanel;
    private float OpenumanjiwordPanel = 16.0f;
    public AudioSource Jumanjiword;
    string JumanjiText = "A GAME FOR THOSE WHO SEEK TO FIND A WAY TO LEAVE THEIR WORLD BEHIND";
    public TextMeshProUGUI Text;
    string[] jumangiTextList;
    int i = -1;

    public GameObject Menu;
    void Start()
    {
        jumangiTextList = JumanjiText.Split(' ');
        Drums.Play();
        Invoke("ShowJumanjiTitlePanel", open);
        Invoke("HideJumanjiTitlePanel", delete);
        
        InvokeRepeating("ShowJumanjiwordPanel", OpenumanjiwordPanel, 0.5f);
        Invoke("PlaysoundJumanjiword", 16.1f);


        Invoke("MainMenu", 24f);
    }

    private void ShowJumanjiTitlePanel()
    {
        JumanjiTitlePanel.gameObject.SetActive(true);
    }

    private void HideJumanjiTitlePanel()
    {
        JumanjiTitlePanel.gameObject.SetActive(false);
    }

    private void ShowJumanjiwordPanel()
    {
        i++;
        if (i >= jumangiTextList.Length)
        {
            JumanjiwordPanel.gameObject.SetActive(false);
            return; 
        }     
        Text.text += jumangiTextList[i] + " ";   
    }

    private void PlaysoundJumanjiword()
    {
        JumanjiwordPanel.gameObject.SetActive(true);
        Jumanjiword.Play();
    }

    private void MainMenu()
    {
        Menu.gameObject.SetActive(true);
    }
}
