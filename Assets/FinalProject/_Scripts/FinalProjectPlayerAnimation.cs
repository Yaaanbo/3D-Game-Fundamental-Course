using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalProjectPlayerAnimation : MonoBehaviour
{
    private const string IS_JUMPING_PARAMS = "isJumping";

    [Header("Class Reference")]
    [SerializeField] private FinalProjectPlayerController player;

    [Header("Animation Component")]
    [SerializeField] private Animator anim;

    void Update()
    {
        anim.SetBool(IS_JUMPING_PARAMS, player.isJumping);
    }
}
