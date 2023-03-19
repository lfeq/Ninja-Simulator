using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnShurikens : MonoBehaviour
{
    [SerializeField] private Transform kunaiInitialPosition;
    [SerializeField] private Transform shurikenInitialPosition;
    [SerializeField] private Transform BombInitialPosition;
    [SerializeField] private GameObject kunaiPrefab;
    [SerializeField] private GameObject shurikenPrefab;

    private Vector3 kunaiPosition;
    private Vector3 shurikenPosition;
    private Vector3 BombPosition;

    public delegate void ThrowedShuriken();
    public static ThrowedShuriken OnThrowShuriken;
    public static ThrowedShuriken OnThrowKunai;
    public static ThrowedShuriken OnThrowBomb;

    private void OnEnable()
    {
        OnThrowKunai += SpawnKunai;
        OnThrowShuriken += SpawnShuriken;
        OnThrowBomb += SpawnBomb;
    }

    private void OnDisable()
    {
        OnThrowKunai -= SpawnKunai;
        OnThrowShuriken -= SpawnShuriken;
        OnThrowBomb += SpawnBomb;
    }

    private void Start()
    {
        kunaiPosition = kunaiInitialPosition.transform.position;
        shurikenPosition = shurikenInitialPosition.transform.position;
        BombPosition = BombInitialPosition.transform.position;
    }

    public void SpawnKunai()
    {
        Instantiate(kunaiPrefab, kunaiPosition, Quaternion.identity);
    }

    public void SpawnShuriken()
    {
        Instantiate(shurikenPrefab, shurikenPosition, Quaternion.identity);
    }

    public void SpawnBomb()
    {
        Instantiate(shurikenPrefab, shurikenPosition, Quaternion.identity);
    }
}
