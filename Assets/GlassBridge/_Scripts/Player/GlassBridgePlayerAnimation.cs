using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBridgePlayerAnimation : MonoBehaviour
{
    private const string IS_FALLING_PARAMS = "isFalling";
    private const string IS_RUNNING_PARAMS = "isRunning";
    private const string IS_GROUNDED_PARAMS = "isGrounded";

    [SerializeField] private GlassBridgePlayerController player;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(IS_GROUNDED_PARAMS, player.isGrounded);
        anim.SetBool(IS_RUNNING_PARAMS, player.isRunning);
        anim.SetBool(IS_FALLING_PARAMS, player.isFalling);
    }
}
