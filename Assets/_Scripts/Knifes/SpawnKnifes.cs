using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnKnifes : MonoBehaviour
{
    public GameObject shuriken;
    public GameObject kunai;
    public GameObject Bomb;
    public Transform leftHand;
    public Transform rightHand;

    private GameObject temp_shuriken;
    private GameObject temp_kunai;

    //Se llama cuando se presiona el boton que esta abajo del gatillo izquierdo
    public void LeftGrip(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            //Logica cuando se presiona por primera vez el boton
            temp_shuriken = Instantiate(shuriken, leftHand);
        }

        if(context.canceled)
        {
            //Logica cuando se deja de presionar el boton
            Destroy(temp_shuriken);
        }
    }

    //Se llama cuando se presiona el gatillo izquierdo
    public void LeftTrigger(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Logica cuando se presiona por primera vez el boton
            temp_kunai = Instantiate(kunai, leftHand);
        }

        if (context.canceled)
        {
            //Logica cuando se deja de presionar el boton
            Destroy(temp_kunai);
        }
    }

    //Se llama cuando se presiona el boton que esta abajo del gatillo derecho
    public void RightGrip(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Logica cuando se presiona por primera vez el boton
            temp_shuriken = Instantiate(shuriken, rightHand);
        }

        if (context.canceled)
        {
            //Logica cuando se deja de presionar el boton
            Destroy(temp_shuriken);
        }
    }

    //Se llama cuando se presiona el gatillo dercho
    public void RightTrigger(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Logica cuando se presiona por primera vez el boton
            temp_kunai = Instantiate(kunai, rightHand);
        }

        if (context.canceled)
        {
            //Logica cuando se deja de presionar el boton
            //Destroy(temp_kunai);
        }
    }
}
