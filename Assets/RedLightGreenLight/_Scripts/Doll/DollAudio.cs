using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip redLightSFX, greenLightSFX, shootingSFX;

    public void PlayRedLightSFX()
    {
        source.PlayOneShot(redLightSFX);
    }

    public void PlayGreenLightSFX()
    {
        source.PlayOneShot(greenLightSFX);
    }

    public void PlayShootingSFX()
    {
        source.PlayOneShot(shootingSFX);
    }
}
