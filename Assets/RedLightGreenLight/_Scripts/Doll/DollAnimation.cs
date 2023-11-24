using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollAnimation : MonoBehaviour
{
    private const string GREEN_LIGHT_PARAM = "isGreenLight";
    [SerializeField] private DollBehaviour behaviour;
    [SerializeField] private Animator anim;
    

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(GREEN_LIGHT_PARAM, behaviour.isGreenLight);
    }
}
