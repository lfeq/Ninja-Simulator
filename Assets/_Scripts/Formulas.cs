using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Formulas
{
    public float Distance(Vector3 a, Vector3 b)
    {
        float x = Mathf.Pow((b.x - a.x), 2); // Restar x_b - x_a y elevarlo al cuadrado
        float y = Mathf.Pow((b.y - a.y), 2); // Restar y_b - y_a y elevarlo al cuadrado
        float z = Mathf.Pow((b.z - a.z), 2); // Restar z_b - z_a y elevarlo al cuadrado

        return Mathf.Sqrt(x + y + z);
    }

    public float Magnitud(Vector3 a)
    {
        float x = Mathf.Pow(a.x, 2);
        float y = Mathf.Pow(a.y, 2);
        float z = Mathf.Pow(a.z, 2);

        return Mathf.Sqrt(x + y + z);
    }

    public Vector3 Normalizar(Vector3 a)
    {
        float mag = Magnitud(a);

        return a / mag;
    }

    public float ProductoPunto(Vector3 a, Vector3 b)
    {
        return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
    }

    public Vector3 ProductoCruz(Vector3 a, Vector3 b)
    {
        float x = (a.y * b.z) - (a.z * b.y);
        float y = (a.z * b.x) - (a.x * b.z);
        float z = (a.x * b.y) - (a.y * b.x);

        return new Vector3(x, y, z);
    }

    public Vector3 MovePos(Vector3 inicialPos, Vector3 distanceToMove)
    {
        return inicialPos + distanceToMove;
    }

    public Vector3 MoveToPosition(Vector3 currentPosition, Vector3 targetPosition, float speed, out bool isInTarget)
    {
        isInTarget = false;
        Vector3 vector3Distance = targetPosition - currentPosition;

        float distance = Distance(currentPosition, targetPosition);

        if(distance <= 0.1f)
        {
            isInTarget = true;
            return targetPosition;
        }

        Vector3 normalizedDistasnce = Normalizar(vector3Distance);

        return currentPosition + normalizedDistasnce * speed;
    }

    public Vector3 RotarEnX(Vector3 inicialPos, float angle)
    {
        float x = (1 * inicialPos.x) + (0 * inicialPos.y) + (0 * inicialPos.z);
        float y = (0 * inicialPos.x) + (Mathf.Cos(angle) * inicialPos.y) + (-Mathf.Sin(angle) * inicialPos.z);
        float z = (0 * inicialPos.x) + (Mathf.Sin(angle) * inicialPos.y) + (Mathf.Cos(angle) * inicialPos.z);

        return new Vector3(x, y, z);
    }

    public Vector3 RotarEnY(Vector3 inicialPos, float angle)
    {
        float x = (Mathf.Cos(angle) * inicialPos.x) + (0 * inicialPos.y) + (Mathf.Sin(angle) * inicialPos.z);
        float y = (0 * inicialPos.x) + (1 * inicialPos.y) + (0 * inicialPos.z);
        float z = (-Mathf.Sin(angle) * inicialPos.x) + (0 * inicialPos.y) + (Mathf.Cos(angle) * inicialPos.z);

        return new Vector3(x, y, z);
    }

    public Vector3 RotarEnZ(Vector3 inicialPos, float angle)
    {
        float x = (Mathf.Cos(angle) * inicialPos.x) + (-Mathf.Sin(angle) * inicialPos.y) + (0 * inicialPos.z);
        float y = (Mathf.Sin(angle) * inicialPos.x) + (Mathf.Cos(angle) * inicialPos.y) + (0 * inicialPos.z);
        float z = (0 * inicialPos.x) + (0 * inicialPos.y) + (1 * inicialPos.z);

        return new Vector3(x, y, z);
    }
}
