using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Time Settings")]
    [SerializeField] private float gametimeInMinutes;
    private float gametime;

    [Header("Enemy Count Settings")]
    [SerializeField] private int maxEnemies;
    private int defeatedEnemies = 0;

    private void Start()
    {
        gametime = gametimeInMinutes * 60;
    }

    private void Update()
    {
        CountDownTime();
    }

    private void CountDownTime()
    {
        gametime -= Time.deltaTime;
    }

    public void DefeatEnemy()
    {
        defeatedEnemies++;

        if (defeatedEnemies == maxEnemies)
            EndGame();
    }

    private void EndGame()
    {
        //Codigo para terminar juego
    }
}
