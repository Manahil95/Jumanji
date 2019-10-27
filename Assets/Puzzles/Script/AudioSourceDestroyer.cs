using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAudioSource", GetComponent<AudioSource>().clip.length);
    }

    void DestroyAudioSource()
    {
        Destroy(gameObject);
    }
}
