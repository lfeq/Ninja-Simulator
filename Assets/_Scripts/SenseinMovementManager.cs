using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SenseinMovementManager : MonoBehaviour
{
    [SerializeField] private Transform position1;
    [SerializeField] private Transform position2;
    [SerializeField] private Transform playerPosition;
    private bool isAtFirstPosition = true;
    private Formulas formulas;

    // Start is called before the first frame update
    void Start()
    {
        formulas = new Formulas();
        
        LookAtPlayer();


        //float productoPunto = formulas.ProductoPunto(transform.position, playerPosition.position);
        //float magA = formulas.Magnitud(transform.position);
        //float magB = formulas.Magnitud(playerPosition.position);

        //float angulo = Mathf.Acos(productoPunto / (magA * magB));
        //angulo = angulo * Mathf.Rad2Deg;
        //print(angulo);
    }

    public void ChangePosition()
    {
        if (isAtFirstPosition)
            transform.position = position2.position;
        if (!isAtFirstPosition)
            transform.position = position1.position;

        isAtFirstPosition = !isAtFirstPosition;
    }

    public void LookAtPlayer()
    {
        transform.rotation = Quaternion.Euler(formulas.VerObjeto(transform.position, playerPosition.position));
    }
}
