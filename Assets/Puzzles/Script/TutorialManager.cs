using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public float WaitTime;

    void Update()
    {
        for(int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[popUpIndex].SetActive(true);
            }
            else
            {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                popUpIndex++;
            }
            else if (popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2)
            {
                if (WaitTime <= 0)
                {
                    // Spanwer.setActive(true);
                }
                else
                {
                    WaitTime -= Time.deltaTime;
                }
            }

        }
    }
}
