using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private const string MOVEMENT_BLEND_PARAM = "Movement";
    [SerializeField] private PlayerController controller;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(MOVEMENT_BLEND_PARAM, controller.animThreshold);
    }
}
