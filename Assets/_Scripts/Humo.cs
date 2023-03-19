using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humo : MonoBehaviour
{

    public float timerDuration = 10f;
    private float timer;
    void Start()
    {
        timer = timerDuration;
    }


    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timer = timerDuration;
        }
    }
}
