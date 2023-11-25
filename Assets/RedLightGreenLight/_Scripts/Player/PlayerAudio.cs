using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip gotShotSFX;

    public void PlayDeadAudio()
    {
        source.PlayOneShot(gotShotSFX);
    }
}
