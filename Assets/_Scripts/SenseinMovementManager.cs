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
        Vector3 direction = formulas.Direccion(transform.position, playerPosition.position);
        float angulo = direction.z / direction.x;
        float ang = Mathf.Atan(angulo);

        //usamos trigonomeria
        print(angulo);
        print(ang);

        print(formulas.RotarEnY(transform.position, ang));
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
        transform.LookAt(playerPosition.position);
    }
}
