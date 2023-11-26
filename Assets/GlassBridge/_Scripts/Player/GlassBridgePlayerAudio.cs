using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBridgePlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] clips;
    
    public void PlaySFX(int _clipIndex)
    {
        source.PlayOneShot(clips[_clipIndex]);
    }
}
