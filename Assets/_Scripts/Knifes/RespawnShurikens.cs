using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShurikens : MonoBehaviour
{
    [SerializeField] private Transform kunaiInitialPosition;
    [SerializeField] private Transform shurikenInitialPosition;
    [SerializeField] private GameObject kunaiPrefab;
    [SerializeField] private GameObject shurikenPrefab;

    private Vector3 kunaiPosition;
    private Vector3 shurikenPosition;

    public delegate void ThrowedShuriken();
    public static ThrowedShuriken OnThrowShuriken;
    public static ThrowedShuriken OnThrowKunai;

    private void OnEnable()
    {
        OnThrowKunai += SpawnKunai;
        OnThrowShuriken += SpawnShuriken;
    }

    private void OnDisable()
    {
        OnThrowKunai -= SpawnKunai;
        OnThrowShuriken -= SpawnShuriken;
    }

    private void Start()
    {
        kunaiPosition = kunaiInitialPosition.transform.position;
        shurikenPosition = shurikenInitialPosition.transform.position;
    }

    public void SpawnKunai()
    {
        Instantiate(kunaiPrefab, kunaiPosition, Quaternion.identity);
    }

    public void SpawnShuriken()
    {
        Instantiate(shurikenPrefab, shurikenPosition, Quaternion.identity);
    }
}
