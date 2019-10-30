using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Play : MonoBehaviour
{
    public static Game_Play Instance;

    public int PlayerAvatarIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this);
    }

 
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.Four))
        {
            SceneManager.LoadScene("Forest_House");
        }

        if (OVRInput.Get(OVRInput.Button.One))
        {
            SceneManager.LoadScene("Cave Latest");
        }

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene("Maze Latest");
        }
    }
}
