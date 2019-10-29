using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
