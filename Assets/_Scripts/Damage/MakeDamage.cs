using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<TakeDamage>(out TakeDamage enemy))
        {
            enemy.takeDamage?.Invoke();
        }
    }
}
