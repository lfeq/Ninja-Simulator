using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SenseiAnimationManager : MonoBehaviour
{
    public delegate void AnimationChange();
    public static AnimationChange OnStartTalking;
    public static AnimationChange OnStopTalking;

    private Animator anim;
    private const string CONST_TALKING = "IsTalking";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        OnStartTalking += StartTalking;
        OnStopTalking += StopTalking;
    }

    private void OnDisable()
    {
        
    }

    private void StartTalking()
    {
        anim.SetBool(CONST_TALKING, true);
    }

    private void StopTalking()
    {
        anim.SetBool(CONST_TALKING, false);
    }
}
