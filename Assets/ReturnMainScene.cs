using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Game_Play.Instance.PuzzleFinished = true;
            Invoke("GoBackToMainScene", 2f);
        }
    }

    void GoBackToMainScene()
    {
        SceneManager.LoadScene("Forest_House");
    }
}
