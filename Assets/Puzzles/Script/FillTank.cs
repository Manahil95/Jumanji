using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillTank : MonoBehaviour
{
    public Transform Water;
    public Transform Target;

    public void RaiseWater()
    {
        Water.position = Vector3.MoveTowards(Water.position, Target.position, 0.005f);
        if (Water.position.y >= Target.position.y)
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
