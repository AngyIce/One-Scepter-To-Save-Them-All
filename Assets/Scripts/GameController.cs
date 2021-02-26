using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public Text timeCounter;
    public bool gamePlaying { get; private set; }
    private float startTime, remainingTime;
    TimeSpan timePlaying;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gamePlaying = false;
        BeginGame();
    }

    private void BeginGame()
    {
        gamePlaying = true;
        startTime = Time.time + 10f;
    }

    private void Update()
    {
        if (gamePlaying == true)
        {
            remainingTime = Time.time - startTime;
            Debug.Log(remainingTime);
            timePlaying = TimeSpan.FromSeconds(remainingTime);

            string timePlayingString = "TIMER: " + timePlaying.ToString("mm' : 'ss'.'ff");
            timeCounter.text = timePlayingString;
        }

        if (remainingTime > 0.0f)
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        gamePlaying = false;
    }
}
