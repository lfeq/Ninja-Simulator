using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Game Time Settings")]
    [SerializeField] private float gametimeInMinutes;
    [SerializeField] private TMP_Text gameTimeText;
    private float gametime;

    [Header("Enemy Count Settings")]
    [SerializeField] private int maxEnemies;
    private int defeatedEnemies = 0;

    [Header("End Game Settings")]
    public UnityEvent winGame;
    public UnityEvent loseGame;

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

        float minutes = Mathf.FloorToInt(gametime / 60);
        float seconds = Mathf.FloorToInt(gametime % 60);

        gameTimeText.text = minutes.ToString() + ":" + seconds.ToString();

        if(gametime <= 0)
        {
            EndGame();
        }
    }

    public void DefeatEnemy()
    {
        defeatedEnemies++;

        if (defeatedEnemies == maxEnemies)
            WinGame();
    }

    private void EndGame()
    {
        loseGame.Invoke();
    }

    private void WinGame()
    {
        
        winGame.Invoke();
    }
}
