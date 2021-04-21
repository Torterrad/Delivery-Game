using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Accelerate, CarHorn, CollectSound, CrashSound, MenuSound, PauseSound, UnPauseSound, SlowDown;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        Accelerate = Resources.Load<AudioClip>("Accelerate");
        CarHorn = Resources.Load<AudioClip>("Car horn");
        CollectSound = Resources.Load<AudioClip>("Collect or drop off sound");
        CrashSound = Resources.Load<AudioClip>("Crash noise");
        MenuSound = Resources.Load<AudioClip>("Menu Option Select");
        PauseSound = Resources.Load<AudioClip>("Pause Sound");
        UnPauseSound = Resources.Load<AudioClip>("UnPause Sound");
        SlowDown = Resources.Load<AudioClip>("Slow down sound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Accelerate":
                audioSrc.PlayOneShot(Accelerate);
                break;
            case "CarHorn":
                audioSrc.PlayOneShot(CarHorn);
                break;
            case "CollectSound":
                audioSrc.PlayOneShot(CollectSound);
                break;
            case "CrashSound":
                audioSrc.PlayOneShot(CrashSound);
                break;
            case "MenuSound":
                audioSrc.PlayOneShot(MenuSound);
                break;
            case "PauseSound":
                audioSrc.PlayOneShot(PauseSound);
                break;
            case "UnPauseSound":
                audioSrc.PlayOneShot(UnPauseSound);
                break;
            case "SlowDown":
                audioSrc.PlayOneShot(SlowDown);
                break;
        }
    }
}