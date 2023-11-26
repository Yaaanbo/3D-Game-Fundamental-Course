using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBridgeGlassAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip shatterSFX;

    public void PlayShatterSFX() => source.PlayOneShot(shatterSFX);
}
