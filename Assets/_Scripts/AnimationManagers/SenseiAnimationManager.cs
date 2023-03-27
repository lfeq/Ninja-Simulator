using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SenseiAnimationManager : MonoBehaviour
{
    public delegate void AnimationChange();
    public static AnimationChange OnStartTalking;
    public static AnimationChange OnStopTalking;
    public static AnimationChange OnStartPointing;

    private Animator anim;
    private const string CONST_TALKING = "IsTalking";
    private const string CONST_POINTING = "Pointing";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        OnStartTalking += StartTalking;
        OnStopTalking += StopTalking;
        OnStartPointing += StartPointing;
    }

    private void OnDisable()
    {
        OnStartTalking -= StartTalking;
        OnStopTalking -= StopTalking;
        OnStartPointing -= StartPointing;
    }

    private void StartTalking()
    {
        anim.SetBool(CONST_TALKING, true);
    }

    private void StopTalking()
    {
        anim.SetBool(CONST_TALKING, false);
    }

    private void StartPointing()
    {
        print("Apuntando");
        anim.SetTrigger(CONST_POINTING);
    }
}
