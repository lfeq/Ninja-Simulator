using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPositions;
    [SerializeField] private float movementSpeed;
    private Formulas formulas;
    private int currentPatrolPosition;
    private bool isMovingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        formulas = new Formulas();
        currentPatrolPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool inDestination;
        transform.position = formulas.MoveToPosition(transform.position, patrolPositions[currentPatrolPosition].position, movementSpeed * Time.deltaTime, out inDestination);   
        
        if(inDestination)
        {
            MoveToNextLocation();
        }//Cambiar de direccion
    }

    private void MoveToNextLocation()
    {
        if(isMovingForward)
        {
            currentPatrolPosition++;

            if(currentPatrolPosition >= patrolPositions.Length) 
                isMovingForward = false;
        }

        if(!isMovingForward)
        {
            currentPatrolPosition--;

            if (currentPatrolPosition == 0)
                isMovingForward = true;
        }
    }
}
