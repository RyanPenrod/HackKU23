using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip crunch;
    public static AudioClip meat;
    public static AudioClip grow;
    public static AudioClip bee;
    public static AudioClip cheer;

    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        crunch = Resources.Load<AudioClip>("crunch");
        meat = Resources.Load<AudioClip>("meat");
        grow = Resources.Load<AudioClip>("grow");
        bee = Resources.Load<AudioClip>("1up");
        cheer = Resources.Load<AudioClip>("cheer");
    }

    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "crunch":
                audioSrc.PlayOneShot(crunch, 0.6f);
                break;
            
            case "meat":
                audioSrc.PlayOneShot(meat);
                break;

            case "grow":
                audioSrc.PlayOneShot(grow);
                break;

            case "1up":
                audioSrc.PlayOneShot(bee);
                break;

            case "cheer":
                audioSrc.PlayOneShot(cheer);
                break;
        }
    }
}
