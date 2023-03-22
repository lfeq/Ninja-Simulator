using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Die : MonoBehaviour
{
    public UnityEvent die;

    public void InvokeDie()
    {
        die.Invoke();
    }
}
