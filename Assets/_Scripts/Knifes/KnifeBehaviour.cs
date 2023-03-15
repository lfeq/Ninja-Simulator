using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 lastPositon;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    public void OnThrowKunai()
    {
        RespawnShurikens.OnThrowKunai.Invoke();
    }

    public void OnThrowShuriken()
    {
        RespawnShurikens.OnThrowShuriken.Invoke();
    }
}
