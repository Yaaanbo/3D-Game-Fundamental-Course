using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBehaviour : MonoBehaviour
{
    public bool isBreakable { get; set; }

    [Header("Class References")]
    [SerializeField] private GlassBridgeGlassAudio glassAudio;

    [Header("Parent Components")]
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private BoxCollider boxColl;

    [Header("Broken Glass")]
    [SerializeField] private GameObject brokenGlass;

    public void BreakGlass()
    {
        meshRenderer.enabled = false;
        boxColl.enabled = false;
        brokenGlass.SetActive(true);


        glassAudio.PlayShatterSFX();
    }
}
