using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public enum SoundName
    {
        PlayerMove,
        WaterFlow,
        ControlStikRotate,
        WaterConnectorRotate,
        FillTank,
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private static Dictionary<SoundName, float> soundTimerDictionary;

    public static void Initialize()
    {
        soundTimerDictionary = new Dictionary<SoundName, float>();
        soundTimerDictionary[SoundName.ControlStikRotate] = 0.0f;
        soundTimerDictionary[SoundName.WaterConnectorRotate] = 0.0f;
    }

    public void PlaySound(SoundName sound)
    {
        if(CanPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

            audioSource.gameObject.AddComponent<AudioSourceDestroyer>();

            GameAssets.SoundAudioClip soundAudioClip = GetAudioClip(sound);

            audioSource.volume = soundAudioClip.Volume;
            audioSource.clip = soundAudioClip.audioClip;
            audioSource.Play();
        }
       
    }

    private bool CanPlaySound(SoundName sound)
    {
        switch (sound)
        {
            default:
               return true;
            case SoundName.ControlStikRotate:
                if(soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float delaykMax = 0.05f;
                    if(lastTimePlayed + delaykMax < Time.deltaTime)
                    {
                        soundTimerDictionary[sound] = Time.deltaTime;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }

            case SoundName.WaterConnectorRotate:
                if (soundTimerDictionary.ContainsKey(sound))
                {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float delaykMax = 0.05f;
                    if (lastTimePlayed + delaykMax < Time.deltaTime)
                    {
                        soundTimerDictionary[sound] = Time.deltaTime;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
                // break;

        }
    }

    GameAssets.SoundAudioClip GetAudioClip(SoundName sound)
    {
        foreach (GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.SoundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found! ");
        return null;
    }


}
